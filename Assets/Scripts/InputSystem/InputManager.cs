using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public GameControls gameControls { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        gameControls = new GameControls();
        gameControls.Player.Enable();
        gameControls.Camera.Disable();
    }

    public Vector2 GetCharacterMovementVectorNormalized()
    {
        Vector2 inputVector;
        
        inputVector = gameControls.Player.Walk.ReadValue<Vector2>();
        
        return inputVector.normalized;
    }    
    
    public Vector2 GetCameraMovementVectorNormalized()
    {
        Vector2 inputVector;
        
        inputVector = gameControls.Camera.Move.ReadValue<Vector2>();
        
        return inputVector.normalized;
    }

    public void EnableCharacterControls()
    {
        gameControls.Player.Enable();
    }
    
    public void DisableCharacterControls()
    {
        gameControls.Player.Disable();
    }

    public void EnableCameraControls()
    {
        gameControls.Camera.Enable();
    }

    public void DisableCameraControls()
    {
        gameControls.Camera.Disable();
    }

}
