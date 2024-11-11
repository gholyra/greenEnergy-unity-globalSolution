using UnityEngine;

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
    }

    private void Start()
    {
        itemsCollected = 0;
    }

    public void AddItemsCollected()
    {
        itemsCollected++;
    }
}
