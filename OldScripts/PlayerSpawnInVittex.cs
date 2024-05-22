using UnityEngine;

public class PlayerSpawnInVittex : MonoBehaviour
{
    public GameObject playerPrefab; // Префаб игрока
    private GameObject currentPlayer; // Текущий экземпляр игрока

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Получаем позицию курсора в мировых координатах

            // Проверяем, попал ли курсор на вершину графа
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Vertex"))
            {
                if (currentPlayer == null) // Если игрок еще не создан
                {
                    SpawnPlayer(hit.collider.transform.position); // Спавним игрока в позиции вершины
                }
                /*else
                {
                    MovePlayer(hit.collider.transform.position); // Перемещаем игрока к новой вершине
                }*/
            }
        }
    }

    void SpawnPlayer(Vector3 position)
    {
        currentPlayer = Instantiate(playerPrefab, position, Quaternion.identity); // Создаем игрока в указанной позиции
    }

    void MovePlayer(Vector3 position)
    {
        // Проверяем, есть ли между текущей позицией игрока и вершиной линия (ребро)
        RaycastHit2D hit = Physics2D.Raycast(currentPlayer.transform.position, position - currentPlayer.transform.position, Vector2.Distance(position, currentPlayer.transform.position));
        if (hit.collider != null && hit.collider.CompareTag("Edge"))
        {
            currentPlayer.transform.position = position; // Перемещаем игрока к вершине
        }
    }
}
