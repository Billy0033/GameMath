using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{ 
    public GameObject[] gameObjectsArray;
    public int arraySize = 10; // Здесь задайте желаемый размер массива

    void Start()
    {
        // Выделяем память для массива
        gameObjectsArray = new GameObject[arraySize];

        // Получаем все объекты в сцене и сохраняем их в массив
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        // Копируем объекты в массив gameObjectsArray
        int minSize = Mathf.Min(arraySize, allGameObjects.Length);
        for (int i = 0; i < minSize; i++)
        {
            gameObjectsArray[i] = allGameObjects[i];
        }
    }
}

