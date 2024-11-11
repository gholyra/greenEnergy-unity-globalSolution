using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    [SerializeField] private float velocity;

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
        HandleCollectablesTab();
        HandleWalk();
    }

    private void HandleWalk()
    {
        Vector2 inputValue = InputManager.Instance.GetMovementVectorNormalized();
        
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
}
