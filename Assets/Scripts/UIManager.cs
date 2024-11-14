using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
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
            InputManager.Instance.DisableCharacterControls();
        }
        else
        {
            collectablesTabActive = false;
            collectablesTabAnimator.SetBool("IsActive", false);
            InputManager.Instance.EnableCharacterControls();
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
