using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField] private float velocity = 3f;

    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        if (Input.GetMouseButtonDown(0))
        {
            if (InputManager.Instance.gameControls.Camera.enabled)
            {
                if (EnergyLocationBehaviour.Instance.isInCameraView)
                {
                    Debug.Log("Foto Tirada!!");
                    UIManager.Instance.SwitchCameraInterface(true);
                }
                else
                {
                    Debug.Log("O objeto não está totalmente enquadrado dentro da câmera :(");
                }
            }
        }
        HandleCollectablesTab();
        HandleWalk();
    }

    #region Handlers
    private void HandleWalk()
    {
        Vector2 inputValue = InputManager.Instance.GetCharacterMovementVectorNormalized();
        
        moveDirection.x = inputValue.x;
        moveDirection.y = inputValue.y;
        
        rigidBody.velocity = new Vector2(moveDirection.x * velocity, moveDirection.y * velocity);
    }

    private void HandleCollectablesTab()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIManager.Instance.GetCollectablesTabState())
            {
                UIManager.Instance.SetCollectablesTabState(false);
            }
            else
            {
                UIManager.Instance.SetCollectablesTabState(true);
            }
        }
    }
    #endregion

}
