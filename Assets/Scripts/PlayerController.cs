using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField] private float velocity = 3f;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;
    
    private Vector2 moveDirection;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleWalk();
        HandleCameraCall();
        HandleTakePicture();
        HandleCollectablesTab();
        HandleAnimation();
    }

    #region Handlers
    private void HandleWalk()
    {
        Vector2 inputValue = InputManager.Instance.GetCharacterMovementVectorNormalized();
        
        moveDirection.x = inputValue.x;
        moveDirection.y = inputValue.y;

        if (!UIManager.Instance.collectablesTabActive && !InputManager.Instance.gameControls.Camera.enabled)
        {
            rigidBody.velocity = new Vector2(moveDirection.x * velocity, moveDirection.y * velocity);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void HandleCameraCall()
    {
        if (Input.GetKeyDown(KeyCode.E) && !UIManager.Instance.collectablesTabActive)
        {
            if (InputManager.Instance.gameControls.Player.enabled)
            {
                InputManager.Instance.DisableCharacterControls();
                UIManager.Instance.SetCameraInterfaceState(true);
                InputManager.Instance.EnableCameraControls();
            }
            else
            {
                InputManager.Instance.DisableCameraControls();
                UIManager.Instance.SetCameraInterfaceState(false);
                InputManager.Instance.EnableCharacterControls();
            }
        }
    }

    private void HandleTakePicture()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (InputManager.Instance.gameControls.Camera.enabled && !UIManager.Instance.collectablesTabActive)
            {
                foreach (EnergyLocationBehaviour location in LocationsController.Instance.Locations)
                {
                    if (location.isInCameraView && !location.isRegistered)
                    {
                        Debug.Log("Foto Tirada!!");
                        UIManager.Instance.SwitchCameraInterface(true);
                        location.OnPictured();
                    }
                    else if (location.isInCameraView && location.isRegistered)
                    {
                        Debug.Log("O objeto já foi registrado!");
                        UIManager.Instance.SwitchCameraInterface(false);
                    }
                    else
                    {
                        Debug.Log("O objeto não está enquadrado dentro da câmera! :(");
                        UIManager.Instance.SwitchCameraInterface(false);
                    }
                }
            }
        }
    }
    
    private void HandleCollectablesTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIManager.Instance.collectablesTabActive)
            {
                UIManager.Instance.SetCollectablesTabState(false);
            }
            else
            {
                UIManager.Instance.SetCollectablesTabState(true);
            }
        }
    }
    
    private void HandleAnimation()
    {
        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (!playerAnimator.GetBool("IsRunning") && moveDirection != Vector2.zero)
        {
            playerAnimator.SetBool("IsRunning", true);
        }
        else if (playerAnimator.GetBool("IsRunning") && moveDirection == Vector2.zero)
        {
            playerAnimator.SetBool("IsRunning", false);
        }
    }
    #endregion

}
