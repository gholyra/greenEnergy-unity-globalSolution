using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Tutorial Screen")]
    [SerializeField] private GameObject tutorialScreen;
    
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;
    
    [Header("Camera Components")] 
    [SerializeField] private GameObject cameraInterface;
    [SerializeField] private Sprite cameraCorrectFrame;
    [SerializeField] private Sprite cameraWrongFrame;
    
    [Header("Collectables Tab Component")]
    [SerializeField] private GameObject locationsTab;
    [SerializeField] private Animator locationsTabAnimator;
    
    [Header("Collectable Items")]
    [SerializeField] private GameObject[] locationsIcons;
    
    [Header("Biomass")]
    [SerializeField] private GameObject biomassInfoScreen;
    
    [Header("Wind")]
    [SerializeField] private GameObject windInfoScreen;
    
    [Header("Hidro")]
    [SerializeField] private GameObject hidroInfoScreen;
    
    [Header("Geothermal")]
    [SerializeField] private GameObject geothermalInfoScreen;
    
    [Header("Solar")]
    [SerializeField] private GameObject solarInfoScreen;

    public bool collectablesTabActive { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        SetTutorialScreenState(true);
        SetPauseMenuState(false);
        SetCameraInterfaceState(false);
    }

    #region Getters
    public bool GetTutorialScreenState()
    {
        return tutorialScreen.activeSelf;
    }  
    public bool GetPauseMenuState()
    {
        return pauseMenu.activeSelf;
    }
    #endregion
    
    #region Setters
    public void SetTutorialScreenState(bool state)
    {
        tutorialScreen.SetActive(state);
    }    
    
    public void SetPauseMenuState(bool state)
    {
        pauseMenu.SetActive(state);
    }
    
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

    public void SetBiomassInfoScreenState(bool state)
    {
        if (GameManager.Instance.isBiomassRegistered)
            biomassInfoScreen.SetActive(state);
    }

    public void SetWindInfoScreenState(bool state)
    {
        if (GameManager.Instance.isWindRegistered)
            windInfoScreen.SetActive(state);
    }

    public void SetHidroInfoScreenState(bool state)
    {
        if (GameManager.Instance.isHidroRegistered)
            hidroInfoScreen.SetActive(state);
    }

    public void SetGeothermalInfoScreenState(bool state)
    {
        if (GameManager.Instance.isGeothermalRegistered)
            geothermalInfoScreen.SetActive(state);
    }

    public void SetSolarInfoScreenState(bool state)
    {
        if (GameManager.Instance.isSolarRegistered)
            solarInfoScreen.SetActive(state);
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
        for (int i = 0; i < locationsIcons.Length; i++)
        {
            if (locationsIcons[i].name == energyLocation.name)
            {
                locationsIcons[i].GetComponentInChildren<Image>().sprite = energyLocation.GetComponent<SpriteRenderer>().sprite;
                locationsIcons[i].GetComponentInChildren<TextMeshProUGUI>().text = energyLocation.name;
            }
        }
    }
}
