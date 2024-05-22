using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Transform targetCircle;
    public float speed = 5f;
    public GameObject questionPanel; // ������ � ���������
    private bool isFalseCircle = false;
    public Sprite NewSprite;

    public void SetTargetCircle(Transform circle)
    {
        targetCircle = circle;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Vertex"))
                {
                    targetCircle = hit.collider.transform;
                    if (!IsVertexConnected(hit.collider.transform))
                    {
                        // ���� ������� �� ��������� ������, ��������� ��������
                        return;
                    }
                    isMoving = true;
                    isFalseCircle = true;
                }
                if (hit.collider.CompareTag("CircleOk"))
                {
                    targetCircle = hit.collider.transform;
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            MoveToCircle();
        }
    }

    void MoveToCircle()
    {
        if (targetCircle != null)
        {
            Vector3 targetPosition = targetCircle.position;

            // ���������, ���� �� ����������� �� ���� �������� �����
            Collider2D collider = Physics2D.OverlapBox(targetPosition, Vector2.one, 0f, LayerMask.GetMask("Obstacles"));
            if (collider == null)
            {
                // ���������� ����� � �����
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }

            // ���������, �������� �� ����� ������ �����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    // ���������� ������ � ��������
                    ShowQuestionPanel();

                    isFalseCircle = false;
                }
            }
        }
    }

    bool IsVertexConnected(Transform vertex)
    {
        // ���������, ��������� �� ������� � ������ ��� ����� "Edge"
        Collider2D[] colliders = Physics2D.OverlapPointAll(vertex.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Edge"))
            {
                return true;
            }
        }
        return false;
    }

    void ShowQuestionPanel()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(true);
        }
    }
}*/


public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Transform targetCircle;
    public float speed = 5f;
    public GameObject questionPanel; // ������ � ���������
    private bool isFalseCircle = false;
    public Sprite NewSprite;

    public void SetTargetCircle(Transform circle)
    {
        targetCircle = circle;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Vertex"))
                {
                    targetCircle = hit.collider.transform;
                    isMoving = true;
                    isFalseCircle = true;
                }
                if (hit.collider.CompareTag("CircleOk"))
                {
                    targetCircle = hit.collider.transform;
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            MoveToCircle();
        }
    }

    void MoveToCircle()
    {
        if (targetCircle != null)
        {
            Vector3 targetPosition = targetCircle.position;

            // ���������� ����� � �����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ���������, �������� �� ����� ������ �����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    //// �������� ������ � ����������� GameObject
                    //GameObject circleGameObject = targetCircle.gameObject;

                    //// �������� ���
                    //circleGameObject.tag = "CircleOk";

                    //// �������� ������ � ���������� SpriteRenderer
                    //SpriteRenderer spriteRenderer = circleGameObject.GetComponent<SpriteRenderer>();

                    //// ���� ��������� ����, ������ ������
                    //if (spriteRenderer != null)
                    //{
                    //    spriteRenderer.sprite = NewSprite;
                    //}

                    //// ���������� ������ � ��������
                    ShowQuestionPanel();

                    isFalseCircle = false;
                }

            }
        }
    }
    /*void MoveToCircle()
    {
        if (targetCircle != null)
        {
            Vector3 targetPosition = targetCircle.position;

            // ���������, �� ���������� �� ����� ������ �������, �� ����������� ������
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag("Vertex") && !IsConnectedToEdge(collider.transform))
                {
                    // ���� ���������� �������, �� ����������� ������, ��������� �����������
                    return;
                }
            }

            // ���������� ����� � �����
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ���������, �������� �� ����� ������ �����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    // ���������� ������ � ��������
                    ShowQuestionPanel();

                    isFalseCircle = false;
                }
            }
        }
    }

    bool IsConnectedToEdge(Transform vertex)
    {
        // ���������, ��������� �� ������� � ������ ��� ����� "Edge"
        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(vertex.position, 0.1f);
        foreach (Collider2D collider in overlappingColliders)
        {
            if (collider.CompareTag("Edge"))
            {
                return true;
            }
        }
        return false;
    }*/

    void ShowQuestionPanel()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(true);
        }
    }
}

