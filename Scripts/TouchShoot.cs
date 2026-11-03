using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchShoot : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LayerMask shootColliderLayerMask;
    [SerializeField] private LayerMask tutorialColliderLayerMask;

    private Camera cameraMain;
    private Ray ray;
    private Touch touch;
    private string pauseButtonName = "button_PAUSE";
    private string bulletTag = "Bullet";
    private GameObject tutorialHitZone;

    private bool hasClickedPause;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Shoot;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Shoot;
    }

    public void Shoot(Vector2 screenPosition, float time)
    {
        if (!GameManager.isGameOver && !GameManager.isLevelComplete && !GameManager.isPaused && GameManager.isReadyToShoot)
        {
            if (inputManager.GetIsUsingTouchControls() == true)
            {
                Vector3 touchWorldPosition = Vector3.zero;
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        hasClickedPause = false;
                        IsTouchOverPauseUIElement();
                        ray = cameraMain.ScreenPointToRay(touch.position);
                    }
                }

                if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, shootColliderLayerMask))
                {
                    touchWorldPosition = raycastHit.point;
                }
                if (!TutorialManager.isShootingTutorialActive && !TutorialManager.isExplodeTutorialActive && !TutorialManager.isGlassTutorialActive && !TutorialManager.isFallTutorialActive
                    && !TutorialManager.isBridgeTutorialActive)
                {
                    if (!hasClickedPause && raycastHit.transform != null && !raycastHit.transform.CompareTag(bulletTag))
                    {
                        playerController.Shoot(touchWorldPosition, raycastHit);
                    }
                } else
                {
                    if (Physics.Raycast(ray, out RaycastHit hit, 999f, tutorialColliderLayerMask))
                    {
                        touchWorldPosition = hit.point;

                        tutorialHitZone = hit.collider.gameObject;
                    }

                    if (tutorialHitZone != null && hit.collider != null)
                    {
                        playerController.Shoot(touchWorldPosition, hit);
                    } else
                    {
                        Debug.Log("MISSED TUTORIAL HIT ZONE!");
                    }
                }
            }
        }
    }

    private void IsTouchOverPauseUIElement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(touch.position.x, touch.position.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        foreach (RaycastResult result in results)
        {
            if (results.Count > 0)
            {
                if (result.gameObject.name == pauseButtonName)
                {
                    hasClickedPause = true;
                }
            }
        }
    }
}
