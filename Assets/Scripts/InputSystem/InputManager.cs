using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private GameControls gameControls;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        gameControls = new GameControls();
        gameControls.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector;
        
        inputVector = gameControls.Player.Walk.ReadValue<Vector2>();
        
        return inputVector.normalized;
    }

    public void EnableCharacterControls()
    {
        gameControls.Enable();
    }
    
    public void DisableCharacterControls()
    {
        gameControls.Disable();
    }

    public void EnableCameraControls()
    {
        gameControls.Enable();
    }

    public void DisableCameraControls()
    {
        gameControls.Disable();
    }

}
