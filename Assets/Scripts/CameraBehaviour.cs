using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity = 3f;
    
    private Camera cameraComponent;
    private Transform cameraTransform;
    private Vector3 playerPosition;

    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;
    
    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
        cameraTransform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (InputManager.Instance.gameControls.Camera.enabled)
        {
            HandleMove();
            cameraComponent.orthographicSize = 8.5f;
        }
        else
        {
            if (PlayerController.Instance)
            {
                playerPosition = PlayerController.Instance.transform.position;
            }
            cameraComponent.orthographicSize = 5f;
            cameraTransform.position = new Vector3(playerPosition.x, playerPosition.y, cameraTransform.position.z);
        }
        
    }
    
    private void HandleMove()
    {
        Vector2 inputValue = InputManager.Instance.GetCameraMovementVectorNormalized();
        
        moveDirection.x = inputValue.x;
        moveDirection.y = inputValue.y;

        if (!UIManager.Instance.collectablesTabActive)
        {
            rigidBody.velocity = new Vector2(moveDirection.x * velocity, moveDirection.y * velocity);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }
}
