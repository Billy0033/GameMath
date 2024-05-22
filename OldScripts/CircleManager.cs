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
            // Создаем экземпляр круга
            GameObject circle = Instantiate(circlePrefab, GetRandomPosition(), Quaternion.identity);

            // Устанавливаем тег "Circle" для определения круга в скрипте перемещения игрока
            circle.tag = "Circle";

            circles[i] = circle;
        }
    }

    Vector3 GetRandomPosition()
    {
        // Генерируем случайную позицию в пределах определенной области
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        return new Vector3(x, y, 0f);
    }
}

