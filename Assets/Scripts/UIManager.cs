using UnityEngine;
using UnityEngine.Playables;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Collectables Tab Component")]
    [SerializeField] private GameObject collectablesTab;
    [SerializeField] private Animator collectablesTabAnimator;

    public bool collectablesTabActive { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public bool GetCollectablesTabState()
    {
        return collectablesTabActive;
    }
    
    public void SetCollectablesTabState(bool state)
    {
        if (state)
        {
            collectablesTabActive = true;
            collectablesTabAnimator.SetBool("IsActive", true);
            InputManager.Instance.DisableGameControls();
        }
        else
        {
            collectablesTabActive = false;
            collectablesTabAnimator.SetBool("IsActive", false);
            InputManager.Instance.EnableGameControls();
        }
    }
}
