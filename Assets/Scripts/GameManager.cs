using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int itemsCollected;

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
        itemsCollected = 0;
    }
    
    public void AddItemsCollected()
    {
        itemsCollected++;
    }
    
    public void StartGame() 
    {
        SceneManager.LoadScene("GameScene");
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
