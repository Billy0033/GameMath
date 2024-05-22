using UnityEngine;

public class PlayerSpawnInVittex : MonoBehaviour
{
    public GameObject playerPrefab; // ������ ������
    private GameObject currentPlayer; // ������� ��������� ������

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��������� ������� ����� ������ ����
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // �������� ������� ������� � ������� �����������

            // ���������, ����� �� ������ �� ������� �����
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Vertex"))
            {
                if (currentPlayer == null) // ���� ����� ��� �� ������
                {
                    SpawnPlayer(hit.collider.transform.position); // ������� ������ � ������� �������
                }
                /*else
                {
                    MovePlayer(hit.collider.transform.position); // ���������� ������ � ����� �������
                }*/
            }
        }
    }

    void SpawnPlayer(Vector3 position)
    {
        currentPlayer = Instantiate(playerPrefab, position, Quaternion.identity); // ������� ������ � ��������� �������
    }

    void MovePlayer(Vector3 position)
    {
        // ���������, ���� �� ����� ������� �������� ������ � �������� ����� (�����)
        RaycastHit2D hit = Physics2D.Raycast(currentPlayer.transform.position, position - currentPlayer.transform.position, Vector2.Distance(position, currentPlayer.transform.position));
        if (hit.collider != null && hit.collider.CompareTag("Edge"))
        {
            currentPlayer.transform.position = position; // ���������� ������ � �������
        }
    }
}
