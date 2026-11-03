using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class BossController : MonoBehaviour
{
    private float speed = 5f;
    [SerializeField] private Rigidbody hipsRigidbody;
    [SerializeField] private Image alertImage;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform pfDamagePopUp;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 runnerPosition;
    private Collider zombieCollider;
    private string isDeadAnimBoolName = "isDead";
    private string isAttackingAnimBoolName = "isAttacking";
    private string isStoppedAnimBoolName = "isStopped";
    private string runnerTag = "Runner";
    private float camBlendTime = .5f;
    private GameManager gameManager;
    private CameraManager cameraManager;
    private Transform runner;
    private RunnerController runnerController;
    private CreditManager creditManager;
    private int currentPlayerWeaponDamage;
    private float dieForce = 40f;

    private bool hasCaughtPlayer;
    private bool isDead;
    private bool isExploded;
    [SerializeField] private bool isAlerted;
    private bool isStopped;

    public void Start()
    {
        DeactivateRagdoll();
        animator = GetComponent<Animator>();
        animator.enabled = true;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = true;
        zombieCollider = GetComponent<CapsuleCollider>();
        zombieCollider.enabled = true;
        gameManager = FindObjectOfType<GameManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        creditManager = FindObjectOfType<CreditManager>();
        currentPlayerWeaponDamage = FindObjectOfType<ActiveWeapon>().GetWeaponBulletDamage();
    }

    //Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (GetIsDead() == false)
        {
            // Is Alive.
            if (runner == null)
            {
                runner = GameObject.FindGameObjectWithTag(runnerTag).transform;
                runnerController = runner.GetComponent<RunnerController>();
            }
            runnerPosition = runner.transform.position;

            if (!GetHasCaughtPlayer())
            {
                // Is chasing runner.
                if (runnerController.GetIsDead() == false)
                {
                    Chase(speed);
                    navMeshAgent.SetDestination(runnerPosition);
                }
                else
                {
                    Stop();
                }
            }
            else
            {
                // Has caught runner.
                Stop();
            }
        }
    }

    private void Chase(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    private void Stop()
    {
        if (GetIsStopped() == false)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.speed = 0;
            navMeshAgent.SetDestination(transform.position);

            if (runnerController.GetIsDead() == true)
            {
                SetStoppedAnim(true);
            }
            SetIsStopped(true);
        }
    }

    public void AlertZombie()
    {
        if (!GetIsAlerted())
        {
            ZombieController.numberOfAlertedZombies++;
            alertImage.gameObject.SetActive(true);
            cameraManager.SetAlertCamPriority(40);
            Invoke(nameof(TriggerSlowTime), camBlendTime);
            SetIsAlerted(true);
        }
    }

    public void CaughtPlayer()
    {
        if (!GetHasCaughtPlayer())
        {
            transform.LookAt(runnerPosition);
            FindObjectOfType<RunnerController>().Fall();
            cameraManager.SetAlertCamPriority(0);
            cameraManager.EnableGameOverCam();
            SetAttackAnim(true);
            TriggerSlowTime();
            Billboard[] alertIcons = FindObjectsOfType<Billboard>();
            foreach (Billboard alertIcon in alertIcons)
            {
                alertIcon.DisableGameObject();
            }
            gameManager.GameOver();
            SetHasCaughtPlayer(true);
        }
    }

    public void ShowAttackAnim()
    {
        SetAttackAnim(true);
        SetHasCaughtPlayer(true);
    }

    public void RegularDeath(Vector3 direction)
    {
        //navMeshAgent.enabled = false;
        //zombieCollider.enabled = false;
        //SetDieAnim(true);
        ActivateRagdoll();
        ApplyForce(direction * dieForce);
        SetIsDead(true);
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        StartCoroutine(WaitHideHealthBarUI(.5f));
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void ExplosionDeath(Vector3 direction)
    {
        ActivateRagdoll();
        direction.y = 1.2f;
        SetIsDead(true);
        SetIsExploded(true);
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        healthBar.DrainHealth();
        StartCoroutine(WaitHideHealthBarUI(.5f));
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void SquishDeath()
    {
        ActivateRagdoll();
        SetIsDead(true);
        SetIsExploded(true);
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        healthBar.DrainHealth();
        StartCoroutine(WaitHideHealthBarUI(.5f));
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void DisableZombie()
    {
        gameObject.SetActive(false);
    }

    public void TriggerSlowTime()
    {
        if (!GetIsDead())
        {
            gameManager.SlowTime();
        }
    }

    public void TriggerFreezeTime()
    {
        gameManager.FreezeTime();
    }

    private void SetRigidbodiesKinematic(bool isKinematic)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = isKinematic;
        }
    }

    public void ActivateRagdoll()
    {
        navMeshAgent.enabled = false;
        animator.enabled = false;

        SetRigidbodiesKinematic(false);

        zombieCollider.enabled = false;
        StartCoroutine(WaitDestroy(1.5f));
    }

    private void DeactivateRagdoll()
    {
        SetRigidbodiesKinematic(true);
    }

    public void ApplyForce(Vector3 direction)
    {
        hipsRigidbody.AddForce(direction, ForceMode.VelocityChange);
    }

    public void ManageAlertedZombies()
    {
        if (alertImage.gameObject.activeInHierarchy)
        {
            ZombieController.numberOfAlertedZombies--;
            alertImage.gameObject.SetActive(false);
        }
        if (ZombieController.numberOfAlertedZombies == 0)
        {
            cameraManager.SetAlertCamPriority(0);
            if (!GameManager.isGameOver && !GameManager.isLevelComplete && Time.timeScale != 1)
            {
                gameManager.ResumeTime();
            }
        }
    }

    public bool GetIsAlerted()
    {
        return isAlerted;
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public bool GetIsExploded()
    {
        return isExploded;
    }

    public bool GetHasCaughtPlayer()
    {
        return hasCaughtPlayer;
    }

    public bool GetIsStopped()
    {
        return isStopped;
    }

    public void SetDieAnim(bool isDead)
    {
        animator.SetBool(isDeadAnimBoolName, isDead);
    }

    private void SetAttackAnim(bool isAttacking)
    {
        animator.SetBool(isAttackingAnimBoolName, isAttacking);
    }

    private void SetStoppedAnim(bool isStopped)
    {
        animator.SetBool(isStoppedAnimBoolName, isStopped);
    }

    private void SetIsAlerted(bool _isAlerted)
    {
        isAlerted = _isAlerted;
    }

    public void SetIsDead(bool _isDead)
    {
        isDead = _isDead;
    }

    private void SetIsExploded(bool _isExploded)
    {
        isExploded = _isExploded;
    }

    private void SetHasCaughtPlayer(bool _hasCaughtPlayer)
    {
        hasCaughtPlayer = _hasCaughtPlayer;
    }

    private void SetIsStopped(bool _isStopped)
    {
        isStopped = _isStopped;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public IEnumerator WaitHideHealthBarUI(float delay)
    {
        yield return new WaitForSeconds(delay);

        healthBar.SetHealthBarUIActive(false);
    }

    public IEnumerator WaitDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy();
    }

    public DamagePopUp CreateDamagePopUp(Vector3 position, Quaternion rotation)
    {
        Transform damagePopUpTransform = Instantiate(pfDamagePopUp, position, rotation);
        DamagePopUp damagePopup = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopup.NumberSetup(currentPlayerWeaponDamage);

        return damagePopup;
    }
}