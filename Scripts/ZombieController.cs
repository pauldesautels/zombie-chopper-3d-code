using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed = 9f;
    [SerializeField] private Rigidbody hipsRigidbody;
    [SerializeField] private Image alertImage;
    [SerializeField] private Image shootImage;
    [SerializeField] private Image aimCircleImage;
    [SerializeField] private GameObject tutorialHitZone;
    [SerializeField] private Material regularMeshMaterial;
    [SerializeField] private Material deadMeshMaterial;
    [SerializeField] private Transform pfDamagePopUp;
    private float dieForce = 40f;

    private UnityAction<ZombieController> dieAction;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 runnerPosition;
    private Collider zombieCollider;
    private string isDeadAnimBoolName = "isDead";
    private string isAttackingAnimBoolName = "isAttacking";
    private string isStoppedAnimBoolName = "isStopped";
    private string runnerTag = "Runner";
    private string headshotText = "HEADSHOT";
    private float camBlendTime = .5f;
    private GameManager gameManager;
    private CameraManager cameraManager;
    private Transform runner;
    private RunnerController runnerController;
    private CreditManager creditManager;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private MeshRenderer meshRenderer;

    private bool hasCaughtPlayer;
    private bool isDead;
    private bool isExploded;
    private bool isFalling;
    private bool isGettingLaunched;
    [SerializeField] private bool isAlerted;
    private bool isStopped;

    public static int numberOfAlertedZombies;

    [SerializeField] private AnimationClip[] runAnimationClips;
    private float defaultAnimationSpeed = 1;
    private float runAnimation_1Speed = 1.03f;
    private float runAnimation_2Speed = 0.86f;
    private float runAnimation_3Speed = 1f;
    private float runAnimation_4Speed = 0.84f;
    private float runAnimation_5Speed = 1f;
    private float runAnimation_6Speed = 0.9f;
    private AnimatorOverrideController overrides;
    [SerializeField] private Mesh[] zombieMeshes;
    [SerializeField] private Material[] zombieMaterials;
    private Camera cam;
    private bool isInCameraView;

    public void Init(UnityAction<ZombieController> _dieAction)
    {
        DeactivateRagdoll();
        ResetZombie();
        dieAction = _dieAction;
    }

    //Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // In the range of the camera.
            isInCameraView = true;
        }
        else
        {
            isInCameraView = false;
        }

        Move();
    }

    public void ResetZombie()
    {
        int randomMaterialNum = Random.Range(0, zombieMaterials.Length);
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            animator.enabled = true;
            SetAttackAnim(false);
            SetDieAnim(false);
            overrides = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrides;
        }
        else
        {
            animator.enabled = true;
            SetAttackAnim(false);
            SetDieAnim(false);
            overrides = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = overrides;
        }
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = true;
        }
        else
        {
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = true;
        }
        if (zombieCollider == null)
        {
            zombieCollider = GetComponent<CapsuleCollider>();
            zombieCollider.enabled = true;
        }
        else
        {
            zombieCollider.enabled = true;
        }
        if (alertImage.gameObject.activeInHierarchy)
        {
            alertImage.gameObject.SetActive(false);
        }
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        if (cameraManager == null)
        {
            cameraManager = FindObjectOfType<CameraManager>();
        }
        if (creditManager == null)
        {
            creditManager = FindObjectOfType<CreditManager>();
        }
        if (skinnedMeshRenderer == null)
        {
            skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            skinnedMeshRenderer.material = GetMaterial(randomMaterialNum);
        } else
        {
            skinnedMeshRenderer.material = GetMaterial(randomMaterialNum);
        }
        if (meshRenderer == null)
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
            meshRenderer.material = GetMaterial(randomMaterialNum);
        }
        if (cam == null)
        {
            cam = Camera.main;
        }
        else
        {
            meshRenderer.material = GetMaterial(randomMaterialNum);
        }
        SetHasCaughtPlayer(false);
        SetIsDead(false);
        SetIsExploded(false);
        SetIsFalling(false);
        SetIsGettingLaunched(false);
        SetIsAlerted(false);
        SetIsStopped(false);

        int randomAnimNum = Random.Range(0, runAnimationClips.Length);
        overrides["zombie_run_empty"] = GetRunAnimation(randomAnimNum);
        int randomMeshNum = Random.Range(0, zombieMeshes.Length);
        skinnedMeshRenderer.sharedMesh = GetMesh(randomMeshNum);
        transform.LookAt(navMeshAgent.steeringTarget);
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
                    if (!isAlerted)
                    {
                        Chase(speed);
                    } else
                    {
                        if (gameManager.currentLevel <= 10)
                        {
                            Chase(speed * .845f);
                        } else if (gameManager.currentLevel > 10 && gameManager.currentLevel < 20)
                        {
                            Chase(speed * .9f);
                        } else
                        {
                            Chase(speed);
                        }
                    }
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
        if (!GetIsAlerted() && isInCameraView)
        {
            numberOfAlertedZombies++;
            alertImage.gameObject.SetActive(true);
            cameraManager.SetAlertCamPriority(40);
            Invoke(nameof(TriggerSlowTime), camBlendTime);
            SetIsAlerted(true);
        }
    }

    public void SetShootImageActive(bool isActive)
    {
        shootImage.gameObject.SetActive(isActive);
    }

    public void SetAimCircleImageActive(bool isActive)
    {
        aimCircleImage.gameObject.SetActive(isActive);
    }

    public void SetTutorialHitZoneActive(bool isActive)
    {
        tutorialHitZone.SetActive(isActive);
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
        ActivateRagdoll();
        ApplyForce(direction * dieForce);
        StartCoroutine(WaitTriggerDieAction(2f));
        SetIsDead(true);
        skinnedMeshRenderer.material = deadMeshMaterial;
        meshRenderer.material = deadMeshMaterial;
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        // AudioManager.Instance.PlayAudio(deathSound);
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void ExplosionDeath(Vector3 direction)
    {
        ActivateRagdoll();
        direction.y = 1.2f;
        StartCoroutine(WaitTriggerDieAction(1f));
        SetIsDead(true);
        SetIsExploded(true);
        skinnedMeshRenderer.material = deadMeshMaterial;
        meshRenderer.material = deadMeshMaterial;
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void SquishDeath()
    {
        ActivateRagdoll();
        StartCoroutine(WaitTriggerDieAction(1f));
        SetIsDead(true);
        SetIsExploded(true);
        skinnedMeshRenderer.material = deadMeshMaterial;
        meshRenderer.material = deadMeshMaterial;
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void FallDeath()
    {
        ActivateRagdoll();
        StartCoroutine(WaitTriggerDieAction(1f));
        SetIsDead(true);
        SetIsFalling(true);
        skinnedMeshRenderer.material = deadMeshMaterial;
        meshRenderer.material = deadMeshMaterial;
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void LaunchDeath()
    {
        ActivateRagdoll();
        hipsRigidbody.AddForce(transform.up * 65, ForceMode.VelocityChange);
        StartCoroutine(WaitTriggerDieAction(1f));
        SetIsDead(true);
        skinnedMeshRenderer.material = deadMeshMaterial;
        meshRenderer.material = deadMeshMaterial;
        SetIsGettingLaunched(true);
        gameManager.IncreaseKillCount();
        creditManager.AddZombieKillCredit();
        ManageAlertedZombies();
        AudioManager.Instance.Play_sfx_zombie_hit_Random();
    }

    public void DisableZombie()
    {
        gameObject.SetActive(false);
    }

    public void TriggerDieAction()
    {
        dieAction(this);
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
    }

    private void DeactivateRagdoll()
    {
        SetRigidbodiesKinematic(true);
    }

    private void ApplyForce(Vector3 direction)
    {
        hipsRigidbody.AddForce(direction, ForceMode.VelocityChange);
    }

    private IEnumerator WaitTriggerDieAction(float delay)
    {
        yield return new WaitForSeconds(delay);

        TriggerDieAction();
    }

    public void ManageAlertedZombies()
    {
        if (alertImage.gameObject.activeInHierarchy)
        {
            numberOfAlertedZombies--;
            alertImage.gameObject.SetActive(false);
        }
        if (numberOfAlertedZombies == 0)
        {
            cameraManager.SetAlertCamPriority(0);
            if (!GameManager.isGameOver && !GameManager.isLevelComplete && Time.timeScale != 1)
            {
                gameManager.ResumeTime();
            }
        }
    }

    public void FindShootTutorialZombie()
    {
        if (shootImage.gameObject.activeInHierarchy)
        {
            SetShootImageActive(false);
        }
        if (aimCircleImage.gameObject.activeInHierarchy)
        {
            SetAimCircleImageActive(false);
        }
        if (tutorialHitZone.activeInHierarchy)
        {
            SetTutorialHitZoneActive(false);
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

    public bool GetIsFalling()
    {
        return isFalling;
    }

    public bool GetIsGettingLaunched()
    {
        return isGettingLaunched;
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
        animator.speed = defaultAnimationSpeed;
        animator.SetBool(isDeadAnimBoolName, isDead);
    }

    private void SetAttackAnim(bool isAttacking)
    {
        animator.speed = defaultAnimationSpeed;
        animator.SetBool(isAttackingAnimBoolName, isAttacking);
    }

    private void SetStoppedAnim(bool isStopped)
    {
        animator.speed = defaultAnimationSpeed;
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

    private void SetIsFalling(bool _isFalling)
    {
        isFalling = _isFalling;
    }

    private void SetIsGettingLaunched(bool _isGettingLaunched)
    {
        isGettingLaunched = _isGettingLaunched;
    }

    private void SetHasCaughtPlayer(bool _hasCaughtPlayer)
    {
        hasCaughtPlayer = _hasCaughtPlayer;
    }

    private void SetIsStopped(bool _isStopped)
    {
        isStopped = _isStopped;
    }

    public DamagePopUp CreateDamagePopUp(Vector3 position)
    {
        //Transform damagePopUpTransform = Instantiate(pfDamagePopUp, position, rotation);
        Transform damagePopUpTransform = Instantiate(pfDamagePopUp, position, Camera.main.transform.rotation);
        DamagePopUp damagePopup = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopup.TextSetup(headshotText);

        return damagePopup;
    }

    public AnimationClip GetRunAnimation(int number)
    {
        switch (number)
        {
            case 0:
                animator.speed = runAnimation_1Speed;
                return runAnimationClips[0];
            case 1:
                animator.speed = runAnimation_2Speed;
                return runAnimationClips[1];
            case 2:
                animator.speed = runAnimation_3Speed;
                return runAnimationClips[2];
            case 3:
                animator.speed = runAnimation_4Speed;
                return runAnimationClips[3];
            case 4:
                animator.speed = runAnimation_5Speed;
                return runAnimationClips[4];
            case 5:
                animator.speed = runAnimation_6Speed;
                return runAnimationClips[5];
            default:
                animator.speed = runAnimation_1Speed;
                return runAnimationClips[0];
        }
    }

    public Mesh GetMesh(int number)
    {
        switch (number)
        {
            case 0:
                return zombieMeshes[0];
            case 1:
                return zombieMeshes[1];
            case 2:
                return zombieMeshes[2];
            case 3:
                return zombieMeshes[3];
            default:
                return zombieMeshes[0];
        }
    }

    public Material GetMaterial(int number)
    {
        switch (number)
        {
            case 0:
                return zombieMaterials[0];
            case 1:
                return zombieMaterials[1];
            case 2:
                return zombieMaterials[2];
            case 3:
                return zombieMaterials[3];
            case 4:
                return zombieMaterials[4];
            case 5:
                return zombieMaterials[5];
            case 6:
                return zombieMaterials[6];
            case 7:
                return zombieMaterials[7];
            default:
                return zombieMaterials[0];
        }
    }
}
