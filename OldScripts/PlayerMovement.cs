using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Transform targetCircle;
    public float speed = 5f;
    public GameObject questionPanel; // Панель с заданиями
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
                        // Если вершина не соединена ребром, прерываем движение
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

            // Проверяем, есть ли препятствия на пути движения точки
            Collider2D collider = Physics2D.OverlapBox(targetPosition, Vector2.one, 0f, LayerMask.GetMask("Obstacles"));
            if (collider == null)
            {
                // Перемещаем точку к кругу
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }

            // Проверяем, достигла ли точка центра круга
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    // Показываем панель с вопросом
                    ShowQuestionPanel();

                    isFalseCircle = false;
                }
            }
        }
    }

    bool IsVertexConnected(Transform vertex)
    {
        // Проверяем, соединена ли вершина с ребром под тегом "Edge"
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
    public GameObject questionPanel; // Панель с заданиями
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

            // Перемещаем точку к кругу
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Проверяем, достигла ли точка центра круга
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    //// Получаем доступ к компонентам GameObject
                    //GameObject circleGameObject = targetCircle.gameObject;

                    //// Изменяем тэг
                    //circleGameObject.tag = "CircleOk";

                    //// Получаем доступ к компоненту SpriteRenderer
                    //SpriteRenderer spriteRenderer = circleGameObject.GetComponent<SpriteRenderer>();

                    //// Если компонент есть, меняем спрайт
                    //if (spriteRenderer != null)
                    //{
                    //    spriteRenderer.sprite = NewSprite;
                    //}

                    //// Показываем панель с вопросом
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

            // Проверяем, не пересекает ли точка игрока вершины, не соединенные ребром
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag("Vertex") && !IsConnectedToEdge(collider.transform))
                {
                    // Если пересекает вершину, не соединенную ребром, прерываем перемещение
                    return;
                }
            }

            // Перемещаем точку к кругу
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Проверяем, достигла ли точка центра круга
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                targetCircle = null;

                if (isFalseCircle)
                {
                    // Показываем панель с вопросом
                    ShowQuestionPanel();

                    isFalseCircle = false;
                }
            }
        }
    }

    bool IsConnectedToEdge(Transform vertex)
    {
        // Проверяем, соединена ли вершина с ребром под тегом "Edge"
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

