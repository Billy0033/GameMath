using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{ 
    public GameObject[] gameObjectsArray;
    public int arraySize = 10; // ����� ������� �������� ������ �������

    void Start()
    {
        // �������� ������ ��� �������
        gameObjectsArray = new GameObject[arraySize];

        // �������� ��� ������� � ����� � ��������� �� � ������
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        // �������� ������� � ������ gameObjectsArray
        int minSize = Mathf.Min(arraySize, allGameObjects.Length);
        for (int i = 0; i < minSize; i++)
        {
            gameObjectsArray[i] = allGameObjects[i];
        }
    }
}

