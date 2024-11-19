using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            // OnCollected();
        }
    }

    // public void OnCollected()
    // {
    //     GameManager.Instance.AddItemsCollected();
    //     UIManager.Instance.AddLocationToTab(this.gameObject);
    // }
}
