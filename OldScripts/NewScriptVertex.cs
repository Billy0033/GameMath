using UnityEngine;

public class NewScriptVertex : MonoBehaviour
{
    public GameObject vertexPrefab;
    public GameObject fixedVertexPrefab;
    public int numberOfVertices = 2;
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3.8f;
    public float maxY = 2.5f;
    public float minDistance = 1f;
    public Color edgeColor = Color.blue;

    private GameObject[] vertices;
    private GameObject[] allVertices;
    private GameObject player;
    private GameObject currentVertex;
    private LineRenderer[] edgeRenderers;
    private int edgeCount = 0;

    void Start()
    {
        GenerateVertices();
        InitializePlayer();
        InitializeEdgeRenderers();
        DrawEdgesFromFixedVertices();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Vertex"))
            {
                GameObject selectedVertex = hit.collider.gameObject;
                if (selectedVertex != currentVertex)
                {
                    MovePlayerToVertex(selectedVertex);
                    DrawEdgesFromVertex(selectedVertex);
                }
            }
        }
    }

    void GenerateVertices()
    {
        vertices = new GameObject[numberOfVertices];
        allVertices = new GameObject[numberOfVertices + 2];

        for (int i = 0; i < numberOfVertices; i++)
        {
            Vector3 position = GetRandomPosition();
            while (IsOverlapping(position))
            {
                position = GetRandomPosition();
            }

            GameObject vertex = Instantiate(vertexPrefab, position, Quaternion.identity);
            vertex.tag = "Vertex";
            vertices[i] = vertex;
            allVertices[i] = vertex;
        }

        GameObject fixedVertex1 = Instantiate(fixedVertexPrefab, new Vector3(-6.5f, 0f, 0f), Quaternion.identity);
        GameObject fixedVertex2 = Instantiate(fixedVertexPrefab, new Vector3(6.5f, 0f, 0f), Quaternion.identity);
        fixedVertex1.tag = "Vertex";
        fixedVertex2.tag = "Vertex";
        allVertices[numberOfVertices] = fixedVertex1;
        allVertices[numberOfVertices + 1] = fixedVertex2;

        for (int i = 0; i < numberOfVertices + 2; i++)
        {
            for (int j = i + 1; j < numberOfVertices + 2; j++)
            {
                DrawEdge(allVertices[i].transform.position, allVertices[j].transform.position);
            }
        }

        // Вызов метода DrawEdgesFromFixedVertices() после генерации всех вершин
        DrawEdgesFromFixedVertices();
    }


    Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        return new Vector3(x, y, 0f);
    }

    bool IsOverlapping(Vector3 position)
    {
        foreach (GameObject vertex in allVertices)
        {
            if (vertex != null && Vector3.Distance(vertex.transform.position, position) < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    void InitializePlayer()
    {
        player = Instantiate(vertexPrefab, vertices[0].transform.position, Quaternion.identity);
    }

    void InitializeEdgeRenderers()
    {
        edgeRenderers = new LineRenderer[numberOfVertices * (numberOfVertices + 1) / 2 + numberOfVertices]; // Formula for number of edges
        for (int i = 0; i < edgeRenderers.Length; i++)
        {
            edgeRenderers[i] = new GameObject("EdgeRenderer" + i).AddComponent<LineRenderer>();
            edgeRenderers[i].material = new Material(Shader.Find("Sprites/Default"));
            edgeRenderers[i].startColor = edgeColor;
            edgeRenderers[i].endColor = edgeColor;
            edgeRenderers[i].startWidth = 0.2f;
            edgeRenderers[i].endWidth = 0.2f;
            edgeRenderers[i].positionCount = 2;
        }
    }

    void MovePlayerToVertex(GameObject targetVertex)
    {
        if (player != null && targetVertex != null)
        {
            player.transform.position = targetVertex.transform.position;
            currentVertex = targetVertex;
        }
    }

    void DrawEdgesFromVertex(GameObject vertex)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i] == vertex)
            {
                for (int j = i + 1; j < allVertices.Length; j++)
                {
                    DrawEdge(vertex.transform.position, allVertices[j].transform.position);
                }
                break;
            }
        }
    }

    void DrawEdgesFromFixedVertices()
    {
        
        DrawEdge(allVertices[numberOfVertices].transform.position, allVertices[numberOfVertices + 1].transform.position);
        DrawEdge(allVertices[numberOfVertices + 1].transform.position, allVertices[numberOfVertices].transform.position);
    }

    void DrawEdge(Vector3 start, Vector3 end)
    {
        if (edgeCount < edgeRenderers.Length)
        {
            edgeRenderers[edgeCount].SetPosition(0, start);
            edgeRenderers[edgeCount].SetPosition(1, end);
            edgeCount++;
        }
    }
}
