using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public GameObject linePrefab;
    private LineRenderer lineRenderer;
    private GameObject[] circles;

    void Start()
    {
        // ����� ��� ������� � ����� "Circle"
        circles = GameObject.FindGameObjectsWithTag("Circle");

        // ������� LineRenderer ��� ���������� ������
        GameObject lineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = lineObject.GetComponent<LineRenderer>();

        // ���������������� LineRenderer
        lineRenderer.positionCount = circles.Length;
        lineRenderer.loop = true;
    }

    void Update()
    {
        // �������� ������� LineRenderer � ������������ � ��������� ������
        for (int i = 0; i < circles.Length; i++)
        {
            lineRenderer.SetPosition(i, circles[i].transform.position);
        }
    }
}

