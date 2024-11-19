using UnityEngine;

public class EnergyLocationBehaviour : MonoBehaviour
{
    public static EnergyLocationBehaviour Instance;
    
    [SerializeField] private Camera camera;

    private SpriteRenderer targetRenderer;

    public bool isInCameraView { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        targetRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Bounds objectBounds = targetRenderer.bounds;

        // Obtém os 4 pontos de canto do bounding box 2D
        Vector3[] corners = new Vector3[4];
        CalculateCorners(objectBounds, corners);

        // Converte os pontos para coordenadas de viewport
        for (int i = 0; i < 4; i++)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(corners[i]);

            // Verifica se o ponto está fora do viewport
            if (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1)
            {
                isInCameraView = false;
                return;
            }
        }
        isInCameraView = true;
    }
    
    private void CalculateCorners(Bounds bounds, Vector3[] corners)
    {
        corners[0] = new Vector3(bounds.min.x, bounds.min.y, bounds.min.z); // Frente inferior esquerda
        corners[1] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z); // Frente inferior direita
        // ... e assim por diante para os outros 6 cantos
    }

    public void OnPictured()
    {
        GameManager.Instance.AddItemsCollected();
        UIManager.Instance.AddLocationToTab(this.gameObject);
    }
}
