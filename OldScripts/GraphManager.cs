using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GraphManager : MonoBehaviour
{
    public GameObject vertexPrefab; // Префаб для вершин
    public int numVertices; // Количество вершин в графе
    public float minDistanceBetweenVertices = 1f; // Минимальное расстояние между вершинами

    private List<GameObject> vertices = new List<GameObject>(); // Список вершин графа
    private List<LineRenderer> edges = new List<LineRenderer>(); // Список ребер графа

    // Фиксированные вершины
    public Vector3 fixedVertex1 = new Vector3(-6.5f, 0f, 0f);
    public Vector3 fixedVertex2 = new Vector3(6.5f, 0f, 0f);

    void Start()
    {
        GenerateConvexPolygon();
    }

    void GenerateConvexPolygon()
    {
        ClearGraph();

        // Добавляем фиксированные вершины
        AddVertex(fixedVertex1);
        AddVertex(fixedVertex2);

        // Создаем вершины и сохраняем их координаты
        List<Vector3> vertexPositions = new List<Vector3>();
        for (int i = 0; i < numVertices; i++)
        {
            Vector3 vertexPosition = GetRandomVertexPosition(vertexPositions);
            vertexPositions.Add(vertexPosition);
            AddVertex(vertexPosition);
        }

        // Сортируем вершины по полярному углу относительно базовой точки
        Vector3 basePoint = vertexPositions[0];
        vertexPositions = vertexPositions.OrderBy(v => Mathf.Atan2(v.y - basePoint.y, v.x - basePoint.x)).ToList();

        // Создаем ребра многоугольника
        for (int i = 0; i < vertexPositions.Count; i++)
        {
            int nextIndex = (i + 1) % vertexPositions.Count;
            AddEdge(vertexPositions[i], vertexPositions[nextIndex]);
        }
    }

    void AddVertex(Vector3 position)
    {
        GameObject vertex = Instantiate(vertexPrefab, position, Quaternion.identity);
        vertices.Add(vertex);
    }

    void AddEdge(Vector3 startPos, Vector3 endPos)
    {
        GameObject edgeObject = new GameObject("Edge");
        LineRenderer lineRenderer = edgeObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
        edges.Add(lineRenderer);
        edgeObject.tag = "Edge";

        BoxCollider2D boxCollider = edgeObject.AddComponent<BoxCollider2D>();
        float length = Vector3.Distance(startPos, endPos);
        float width = 0.1f;
        boxCollider.size = new Vector2(length, width);
        Vector3 center = (startPos + endPos) / 2f;
        boxCollider.offset = center;
    }

    Vector3 GetRandomVertexPosition(List<Vector3> existingPositions)
    {
        // Генерируем случайную позицию
        float x = Random.Range(-6.0f, 6.0f);
        float y = Random.Range(-2.5f, 4.0f);
        Vector3 position = new Vector3(x, y, 0f);

        // Проверяем, не пересекается ли она с уже существующими вершинами
        foreach (Vector3 existingPosition in existingPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minDistanceBetweenVertices)
            {
                // Если позиция пересекается с уже существующей, генерируем новую
                return GetRandomVertexPosition(existingPositions);
            }
        }

        return position;
    }

    void ClearGraph()
    {
        // Удаляем все вершины
        foreach (GameObject vertex in vertices)
        {
            Destroy(vertex);
        }
        vertices.Clear();

        // Удаляем все ребра
        foreach (LineRenderer edge in edges)
        {
            Destroy(edge.gameObject);
        }
        edges.Clear();
    }

    public void RefreshButton()
    {
        GenerateConvexPolygon();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
