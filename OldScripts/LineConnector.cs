using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer lineRenderer;
    private GameObject[] circles;

    void Start()
    {
        // Найти все объекты с тегом "Circle"
        circles = GameObject.FindGameObjectsWithTag("Circle");

        // Создать LineRenderer для соединения кругов
        GameObject lineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = lineObject.GetComponent<LineRenderer>();

        // Инициализировать LineRenderer
        lineRenderer.positionCount = circles.Length;
        lineRenderer.loop = true;
    }

    void Update()
    {
        // Обновить позиции LineRenderer в соответствии с позициями кругов
        for (int i = 0; i < circles.Length; i++)
        {
            lineRenderer.SetPosition(i, circles[i].transform.position);
        }
    }
}

