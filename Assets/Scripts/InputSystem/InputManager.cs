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

    public void EnableGameControls()
    {
        gameControls.Enable();
    }
    
    public void DisableGameControls()
    {
        gameControls.Disable();
    }
    
}
