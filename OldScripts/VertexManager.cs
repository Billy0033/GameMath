/*using UnityEngine;

public class VertexManager
{
    public Vector3 position;
    public Vertex parent;
    public Vertex nextSibling; // ������ �� ���������� �������-������

    public Vertex(Vector3 position, Vertex parent = null)
    {
        this.position = position;
        this.parent = parent;
    }
}

public class VertexTree
{
    public Vertex root;
    public int numVertices;

    public VertexTree(int N)
    {
        numVertices = N;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ������� ��������� �������
        root = new Vertex(new Vector3(0, screenHeight / 2, 0));

        // ������� ������� �������
        Vertex lastTopVertex = null;
        for (int i = 0; i < N / 2; i++)
        {
            Vertex newVertex = new Vertex(new Vector3(screenWidth / 2, screenHeight / 2 + 50, 0), root);
            if (lastTopVertex != null)
            {
                lastTopVertex.nextSibling = newVertex;
            }
            lastTopVertex = newVertex;
        }

        // ������� ������� �������
        Vertex lastMidVertex = null;
        for (int i = 0; i < N / 3; i++)
        {
            Vertex newVertex = new Vertex(new Vector3(screenWidth / 2, screenHeight / 2, 0), root);
            if (lastMidVertex != null)
            {
                lastMidVertex.nextSibling = newVertex;
            }
            lastMidVertex = newVertex;
        }

        // ������� ������ �������
        Vertex lastBottomVertex = null;
        for (int i = 0; i < N - N / 2 - N / 3; i++)
        {
            Vertex newVertex = new Vertex(new Vector3(screenWidth / 2, screenHeight / 2 - 50, 0), root);
            if (lastBottomVertex != null)
            {
                lastBottomVertex.nextSibling = newVertex;
            }
            lastBottomVertex = newVertex;
        }

        // ������� �������� �������
        Vertex endVertex = new Vertex(new Vector3(screenWidth, screenHeight / 2, 0));
        if (lastBottomVertex != null)
        {
            lastBottomVertex.nextSibling = endVertex;
        }
        else if (lastMidVertex != null)
        {
            lastMidVertex.nextSibling = endVertex;
        }
        else
        {
            lastTopVertex.nextSibling = endVertex;
        }
    }

    // ������� ��� ���������� ������� ���������
    public bool[,] GetAdjacencyMatrix()
    {
        bool[,] matrix = new bool[numVertices, numVertices];

        // TODO: ����������� ������ ���������� ������� ��������� �� ������ ������ ����� ���������
        // ����������� ����� parent � nextSibling ��� ����������� ���������

        return matrix;
    }
}


*//*using UnityEngine;

public class VertexManager : MonoBehaviour
{
    public GameObject vertexPrefab; // ������ �������

    public Vector3 position;
    public VertexManager parent;
    public VertexManager nextSibling;

    public void Initialize(Vector3 position, VertexManager parent = null)
    {
        this.position = position;
        this.parent = parent;

        // ������� ��������� ������� �������
        GameObject vertexInstance = Instantiate(vertexPrefab, position, Quaternion.identity);
        vertexInstance.transform.SetParent(transform);
    }
}

public class VertexTree
{
    public VertexManager root;
    public int numVertices;

    public VertexTree(int N, GameObject vertexPrefab)
    {
        numVertices = N;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ������� ��������� �������
        root = new GameObject("Root").AddComponent<VertexManager>();
        root.Initialize(new Vector3(0, screenHeight / 2, 0));

        // ������� ������� �������
        VertexManager lastTopVertex = null;
        for (int i = 0; i < N / 2; i++)
        {
            VertexManager newVertex = new GameObject("TopVertex_" + i).AddComponent<VertexManager>();
            newVertex.Initialize(new Vector3(screenWidth / 2, screenHeight / 2 + 50, 0), root);
            if (lastTopVertex != null)
            {
                lastTopVertex.nextSibling = newVertex;
            }
            lastTopVertex = newVertex;
        }
        // ������� ������� �������
        Vertex lastMidVertex = null;
        for (int i = 0; i < N / 3; i++)
        {
            Vertex newVertex = new Vertex(new Vector3(screenWidth / 2, screenHeight / 2, 0), root);
            if (lastMidVertex != null)
            {
                lastMidVertex.nextSibling = newVertex;
            }
            lastMidVertex = newVertex;
        }

        // ������� ������ �������
        Vertex lastBottomVertex = null;
        for (int i = 0; i < N - N / 2 - N / 3; i++)
        {
            Vertex newVertex = new Vertex(new Vector3(screenWidth / 2, screenHeight / 2 - 50, 0), root);
            if (lastBottomVertex != null)
            {
                lastBottomVertex.nextSibling = newVertex;
            }
            lastBottomVertex = newVertex;
        }

        // ������� �������� �������
        Vertex endVertex = new Vertex(new Vector3(screenWidth, screenHeight / 2, 0));
        if (lastBottomVertex != null)
        {
            lastBottomVertex.nextSibling = endVertex;
        }
        else if (lastMidVertex != null)
        {
            lastMidVertex.nextSibling = endVertex;
        }
        else
        {
            lastTopVertex.nextSibling = endVertex;
        }

        // ������� �������� �������
        VertexManager endVertex = new GameObject("EndVertex").AddComponent<VertexManager>();
        endVertex.Initialize(new Vector3(screenWidth, screenHeight / 2, 0));
        if (lastBottomVertex != null)
        {
            lastBottomVertex.nextSibling = endVertex;
        }
        else if (lastMidVertex != null)
        {
            lastMidVertex.nextSibling = endVertex;
        }
        else
        {
            lastTopVertex.nextSibling = endVertex;
        }
    }

    // ... (������� GetAdjacencyMatrix)
    // ������� ��� ���������� ������� ���������
    public bool[,] GetAdjacencyMatrix()
    {
        bool[,] matrix = new bool[numVertices, numVertices];

        // TODO: ����������� ������ ���������� ������� ��������� �� ������ ������ ����� ���������
        // ����������� ����� parent � nextSibling ��� ����������� ���������

        return matrix;
    }
}*/
