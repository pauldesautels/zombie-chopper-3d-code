using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour
{
    private float speed = 4f;
    [SerializeField] private Rigidbody hipsRigidbody;
    [SerializeField] private int dieForce;
    [SerializeField] private Image helpWordBubbleImage;
    [SerializeField] private Image shieldImage;
    [SerializeField] private TextMeshProUGUI warningTM;
    [SerializeField] private BridgeInteractSwitch bridgeInteractSwitch;
    [SerializeField] private Cinemachine.CinemachineDollyCart cameraAssistCart;
    private float cameraAssistSpeed;
    [SerializeField] private GameObject crates;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Hazard_Bridge raisedBridge;
    private GameManager gameManager;
    private Vector3 finishLinePosition;
    private Vector3 raisedBridgePosition;
    private float stoppingDistance = .5f;
    private string finishLineTag = "FinishLine";
    private string isJumpingTrigger = "isJumping";
    private string firstRaisedBridgeTag = "Hazard_Bridge_Raised_First";
    private string raisedBridgeTag = "Hazard_Bridge_Raised";
    private string isStuckAnimBoolName = "isStuck";
    private Collider runnerCollider;

    [SerializeField] private AnimationClip[] jumpAnimationClips;
    private AnimatorOverrideController overrides;
    private int animationNumber;

    public static bool isUsingShield;

    private bool isCaught;
    private bool isDead;
    private bool isFallingThroughGlass;
    private bool isGettingLaunched;
    private bool hasFoundRaisedBridge;
    private bool isStuck;
    private bool hasBeenWarned;

    private int numberOfWarningsCount;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        overrides = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrides;
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.currentLevel != 6 && gameManager.currentLevel != 12 && gameManager.currentLevel != 19 && gameManager.currentLevel != 25)
        {
            animationNumber = Random.Range(0, jumpAnimationClips.Length);
        }
        else
        {
            animationNumber = 0;
        }
        overrides["jump_empty"] = GetJumpAnimation(animationNumber);

        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        runnerCollider = GetComponent<CapsuleCollider>();

        DeactivateRagdoll();
        navMeshAgent.stoppingDistance = stoppingDistance;
        CheckForRaisedBridge();
        Checkpoint checkpoint = FindObjectOfType<Checkpoint>();
        if (checkpoint == null || checkpoint.GetIsCheckpointReached() == 0)
        {
            StartCoroutine(WaitHideWordBubble(4f));
        } else
        {
            SetHelpWordBubbleImageActive(false);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GetIsDead())
        {
            Transform finishLine = GameObject.FindGameObjectWithTag(finishLineTag).transform;
            finishLinePosition = finishLine.transform.position;

            if (!isCaught && !GameManager.isLevelComplete && !isStuck)
            {
                Run(speed);
                navMeshAgent.SetDestination(finishLinePosition);

                if (navMeshAgent.remainingDistance != 0)
                {
                    if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                    {
                        animator.applyRootMotion = true;
                        animator.SetTrigger(isJumpingTrigger);
                        navMeshAgent.enabled = false;
                        FindObjectOfType<GameManager>().LevelComplete();
                        if (animationNumber != 0)
                        {
                            crates.SetActive(true);
                        }
                    }
                }

                if (GetHasFoundRaisedBridge() && raisedBridge.GetIsBridgeRaised())
                {
                    raisedBridgePosition = raisedBridge.transform.position;
                    float distanceFromBridge = Vector3.Distance(raisedBridgePosition, transform.position);
                    if (distanceFromBridge <= 6f && !isStuck)
                    {
                        animator.SetBool(isStuckAnimBoolName, true);
                        SetIsStuck(true);
                        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
                        transform.LookAt(playerTransform);
                        if (bridgeInteractSwitch != null && !bridgeInteractSwitch.GetIsSwitchActivate())
                        {
                            bridgeInteractSwitch.TriggerBridgeTutorial();
                        }
                    }
                }
            }
            else
            {
                if (!GameManager.isLevelComplete)
                {
                    Stop();
                    if (isStuck)
                    {
                        if (!raisedBridge.GetIsBridgeRaised())
                        {
                            animator.SetBool(isStuckAnimBoolName, false);
                            SetIsStuck(false);
                        }
                    }
                }
            }
        }
    }

    public void SetStartPosition(Vector3 pos)
    {
        //gameObject.transform.position = pos;
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = true;
            navMeshAgent.Warp(pos);
        }
        else
        {
            navMeshAgent.enabled = true;
            navMeshAgent.Warp(pos);
        }
    }

    private void Run(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    private void Stop()
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.speed = 0;
            navMeshAgent.SetDestination(transform.position);
        }
    }

    public void Fall()
    {
        isCaught = true;
        animator.SetBool("isCaught", true);

        navMeshAgent.enabled = false;
    }

    private void ActivateRagdoll()
    {
        navMeshAgent.enabled = false;
        animator.enabled = false;

        SetRigidbodiesKinematic(false);

        runnerCollider.enabled = false;

        if (!isFallingThroughGlass)
        {
            ApplyDieForce(-transform.forward * dieForce);
        }

        if (isGettingLaunched)
        {
            ApplyDieForce(transform.up * 100f);
        }
    }

    private void DeactivateRagdoll()
    {
        SetRigidbodiesKinematic(true);
    }

    private void ApplyDieForce(Vector3 direction)
    {
        hipsRigidbody.AddForce(direction, ForceMode.VelocityChange);
    }

    private void SetRigidbodiesKinematic(bool isKinematic)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = isKinematic;
        }
    }

    public void Die()
    {
        isDead = true;
        ActivateRagdoll();
        FindObjectOfType<GameManager>().GameOver();
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public IEnumerator WaitHideWordBubble(float delay)
    {
        yield return new WaitForSeconds(delay);

        SetHelpWordBubbleImageActive(false);
    }

    public void SetHelpWordBubbleImageActive(bool isActive)
    {
        helpWordBubbleImage.gameObject.SetActive(isActive);
    }

    public void SetIsFallingThroughGlass(bool _isFallingThroughGlass)
    {
        isFallingThroughGlass = _isFallingThroughGlass;
    }

    public void SetIsGettingLaunched(bool _isGettingLaunched)
    {
        isGettingLaunched = _isGettingLaunched;
    }

    private void SetIsStuck(bool _isStuck)
    {
        isStuck = _isStuck;
        if (cameraAssistCart != null)
        {
            if (_isStuck)
            {
                cameraAssistSpeed = cameraAssistCart.m_Speed;
                cameraAssistCart.m_Speed = 0;
            }
            else
            {
                cameraAssistCart.m_Speed = cameraAssistSpeed;
            }
        }
    }

    public void SetShieldImageActive(bool isActive)
    {
        shieldImage.gameObject.SetActive(isActive);

        if (isActive)
        {
            isUsingShield = true;
        }
    }

    private void CheckForRaisedBridge()
    {
        GameObject _firstRaisedBridge = GameObject.FindGameObjectWithTag(firstRaisedBridgeTag);
        if (_firstRaisedBridge != null)
        {
            raisedBridge = _firstRaisedBridge.GetComponent<Hazard_Bridge>();
            SetHasFoundRaisedBridge(true);
        } else
        {
            GameObject _raisedBridge = GameObject.FindGameObjectWithTag(raisedBridgeTag);
            if (_raisedBridge != null)
            {
                raisedBridge = _raisedBridge.GetComponent<Hazard_Bridge>();
                SetHasFoundRaisedBridge(true);
            }
        }
    }

    public void ResetRaisedBridge()
    {
        raisedBridge.tag = "Untagged";
        CheckForRaisedBridge();
    }

    public IEnumerator WaitResetBridge(float delay)
    {
        yield return new WaitForSeconds(delay);

        ResetRaisedBridge();
    }

    private void SetHasFoundRaisedBridge(bool _hasFoundRaisedBridge)
    {
        hasFoundRaisedBridge = _hasFoundRaisedBridge;
    }

    public bool GetIsCaught()
    {
        return isCaught;
    }

    public bool GetIsStuck()
    {
        return isStuck;
    }

    public bool GetHasFoundRaisedBridge()
    {
        return hasFoundRaisedBridge;
    }

    private void SetWarningTextActive(bool isActive)
    {
        warningTM.gameObject.SetActive(isActive);
    }

    private IEnumerator ShowWaitHideWarningText(float delay)
    {
        SetWarningTextActive(true);
        int numberOfWarningsAllowed;
        if (gameManager.currentLevel <= 10)
        {
            numberOfWarningsAllowed = 10;
        } else
        {
            numberOfWarningsAllowed = 5;
        }
        if (numberOfWarningsCount >= numberOfWarningsAllowed)
        {
            Invoke(nameof(SetHasBeenWarnedTrue), .5f);
        }

        yield return new WaitForSecondsRealtime(delay);

        SetWarningTextActive(false);
    }

    public void ShowWarningText()
    {
        StartCoroutine(ShowWaitHideWarningText(2f));
    }

    public bool GetHasBeenWarned()
    {
        return hasBeenWarned;
    }

    private void SetHasBeenWarnedTrue()
    {
        hasBeenWarned = true;
    }

    public void IncreaseNumberOfWarningsCount()
    {
        numberOfWarningsCount++;
    }

    public AnimationClip GetJumpAnimation(int number)
    {
        switch (number)
        {
            case 0:
                return jumpAnimationClips[0];
            case 1:
                return jumpAnimationClips[1];
            case 2:
                return jumpAnimationClips[2];
            case 3:
                return jumpAnimationClips[3];
            default:
                return jumpAnimationClips[0];
        }
    }
}
