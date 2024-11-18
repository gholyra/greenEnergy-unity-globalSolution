using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Camera Components")] 
    [SerializeField] private GameObject cameraInterface;
    [SerializeField] private Sprite cameraCorrectFrame;
    [SerializeField] private Sprite cameraWrongFrame;
    
    [Header("Collectables Tab Component")]
    [SerializeField] private GameObject collectablesTab;
    [SerializeField] private Animator collectablesTabAnimator;
    
    [Header("Collectable Items")]
    [SerializeField] private GameObject[] collectableItems;

    public bool collectablesTabActive { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        SetCameraInterfaceState(false);
    }

    #region Getters
    public bool GetCollectablesTabState()
    {
        return collectablesTabActive;
    }
    #endregion
    
    #region Setters
    public void SetCameraInterfaceState(bool isActive) 
    {
        cameraInterface.SetActive(isActive);
    }
    
    public void SetCollectablesTabState(bool state)
    {
        if (state)
        {
            collectablesTabActive = true;
            collectablesTabAnimator.SetBool("IsActive", true);
            InputManager.Instance.DisableCharacterControls();
        }
        else
        {
            collectablesTabActive = false;
            collectablesTabAnimator.SetBool("IsActive", false);
            InputManager.Instance.EnableCharacterControls();
        }
    }
    #endregion

    public void SwitchCameraInterface(bool pictureTaken)
    {
        if (pictureTaken)
        {
            cameraInterface.GetComponent<Animator>().enabled = false;
            cameraInterface.GetComponent<Image>().sprite = cameraCorrectFrame;
        }
        else
        {
            cameraInterface.GetComponent<Animator>().enabled = false;
            cameraInterface.GetComponent<Image>().sprite = cameraWrongFrame;
        }
    }
    
    public void AddCollectableToTab(GameObject collectable)
    {
        for (int i = 0; i < collectableItems.Length; i++)
        {
            if (collectableItems[i].CompareTag(collectable.tag))
            {
                collectableItems[i].GetComponentInChildren<Image>().sprite = collectable.GetComponent<SpriteRenderer>().sprite;
                collectableItems[i].GetComponentInChildren<TextMeshProUGUI>().text = collectable.name;
            }
        }
    }
}
