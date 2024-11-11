using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 playerPosition;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (PlayerController.Instance)
        {
            playerPosition = PlayerController.Instance.transform.position;
        }
        cameraTransform.position = new Vector3(playerPosition.x, playerPosition.y, cameraTransform.position.z);        
    }
}
