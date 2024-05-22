using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartScript : MonoBehaviour
{
    public MenuManager menuManager;
    public HealthPanel healthPanel;
    public QuestionLoader questionLoader;
    public GameObject startPanel;
    public TMP_InputField vertex_number;
    void Start()
    {

    }
    public void InitiateGameSession()
    {
        SetLives(3);
        vertex_number.text = "";
        startPanel.SetActive(true);
    }
    void OnDisable()
    {
        SetLives(0);
    }
    void SetLives(int num)
    {
        healthPanel.lives = num;
    }
    public void StartGame()
    {
        try{
            int number = int.Parse(vertex_number.text);
            if(number>14 || number < 6)
            {
                //Debug.LogWarning("nuber wrong " + number);
                return;
            }
            StartGame(number);
        }
        catch(System.Exception e)
        {

        }
    }
    public void CanselGame()
    {
        questionLoader.OrderStopGame();
        menuManager.GoToMainMenu();
    }
    public void EndGame()
    {
        questionLoader.OrderStopGame();
        menuManager.GoToFinishGameSuccess();
    }
    public void FailGame()
    {
        questionLoader.OrderStopGame();
        menuManager.GoToFinishGameFail();
    }
    void StartGame(int number)
    {
        int easy_vertexes = number / 2;
        int medium_vertexes = (number - easy_vertexes) * 2 / 3;
        int hard_vertexes = number - easy_vertexes - medium_vertexes;
        if (hard_vertexes < 1)
        {
            hard_vertexes += 1;
            medium_vertexes -= 1;
        }
        //Debug.LogWarning(" " + easy_vertexes +" "+ medium_vertexes +" "+ hard_vertexes);
        startPanel.SetActive(false);
        questionLoader.OrderStartGame(easy_vertexes,medium_vertexes,hard_vertexes);
    }
}