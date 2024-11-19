using System.Collections;
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
    [SerializeField] private GameObject locationsTab;
    [SerializeField] private Animator locationsTabAnimator;
    
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
            locationsTabAnimator.SetBool("IsActive", true);
            InputManager.Instance.DisableCharacterControls();
        }
        else
        {
            collectablesTabActive = false;
            locationsTabAnimator.SetBool("IsActive", false);
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
            StartCoroutine(RemoveCameraFrameState(3f));
        }
        else
        {
            cameraInterface.GetComponent<Animator>().enabled = false;
            cameraInterface.GetComponent<Image>().sprite = cameraWrongFrame;
            StartCoroutine(RemoveCameraFrameState(3f));
        }
    }

    private IEnumerator RemoveCameraFrameState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        cameraInterface.GetComponent<Animator>().enabled = true;
        cameraInterface.GetComponent<Image>().sprite = null;
    }
    
    public void AddLocationToTab(GameObject energyLocation)
    {
        for (int i = 0; i < collectableItems.Length; i++)
        {
            if (collectableItems[i].name == energyLocation.name)
            {
                collectableItems[i].GetComponentInChildren<Image>().sprite = energyLocation.GetComponent<SpriteRenderer>().sprite;
                collectableItems[i].GetComponentInChildren<TextMeshProUGUI>().text = energyLocation.name;
            }
        }
    }
}
