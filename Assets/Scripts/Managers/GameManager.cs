using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int itemsCollected;

    public bool isBiomassRegistered { get; private set; }    
    public bool isWindRegistered { get; private set; }    
    public bool isHidroRegistered { get; private set; }    
    public bool isGeothermalRegistered { get; private set; }
    public bool isSolarRegistered { get; private set; }
    
    public bool isInTutorial { get; private set; }

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            isInTutorial = true;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            foreach (EnergyLocationBehaviour location in LocationsController.Instance.Locations)
            {
                if (location.name == "Biomassa")
                {
                    isBiomassRegistered = location.isRegistered;
                }
            
                if (location.name == "Eólica")
                {
                    isWindRegistered = location.isRegistered;
                }            
            
                if (location.name == "Hidro")
                {
                    isHidroRegistered = location.isRegistered;
                }            
            
                if (location.name == "Geotérmica")
                {
                    isGeothermalRegistered = location.isRegistered;
                }            
            
                if (location.name == "Solar")
                {
                    isSolarRegistered = location.isRegistered;
                }
            }
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndTutorial()
    {
        isInTutorial = false;
        Time.timeScale = 1;
    }
    
    public void PauseGame(bool state)
    {
        switch (state)
        {
           case true:
               Time.timeScale = 0;
               break;
           case false:
               Time.timeScale = 1;
               break;
        }
    }
    
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void QuitGame() 
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
