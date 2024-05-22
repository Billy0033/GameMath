using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanel : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public int lives = 3;
    void Start()
    {
        ShowLives();
    }

    void Update()
    {
        ShowLives();
    }
    void ShowLives()
    {
        if (lives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lives == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        else if (lives == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
        else if (lives <= 0)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
        }
        else
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
    }
}
