using UnityEngine;

public class CircleManager : MonoBehaviour
{
    public GameObject circlePrefab;
    public int numberOfCircles = 5;
    private GameObject[] circles;

    void Start()
    {
        SpawnCircles();
    }

    void SpawnCircles()
    {
        circles = new GameObject[numberOfCircles];

        for (int i = 0; i < numberOfCircles; i++)
        {
            // ������� ��������� �����
            GameObject circle = Instantiate(circlePrefab, GetRandomPosition(), Quaternion.identity);

            // ������������� ��� "Circle" ��� ����������� ����� � ������� ����������� ������
            circle.tag = "Circle";

            circles[i] = circle;
        }
    }

    Vector3 GetRandomPosition()
    {
        // ���������� ��������� ������� � �������� ������������ �������
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        return new Vector3(x, y, 0f);
    }
}

