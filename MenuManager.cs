using UnityEngine;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public StartScript startScript;
    public EndGameScript endGameScript;
    public GameObject MainMenu;
    public GameObject ShopMenu;
    public GameObject GameMenu;
    public GameObject FinishGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        ShopMenu.SetActive(false);  
        GameMenu.SetActive(false);
        FinishGameMenu.SetActive(false);
    }

    void ShowShopMenu()
    {
        MainMenu.SetActive(false);
        ShopMenu.SetActive(true);
        GameMenu.SetActive(false);
        FinishGameMenu.SetActive(false);
    }

    void ShowGameMenu()
    {
        MainMenu.SetActive(false);
        ShopMenu.SetActive(false);
        GameMenu.SetActive(true);
        FinishGameMenu.SetActive(false);
    }

    void ShowFinishGameMenu()
    {
        MainMenu.SetActive(false);
        ShopMenu.SetActive(false);
        GameMenu.SetActive(false);
        FinishGameMenu.SetActive(true);
    }

    public void GoToFinishGameSuccess()
    {
        ShowFinishGameMenu();
        endGameScript.SetMessage("Вы прошли игру!");
    }

    public void GoToFinishGameFail()
    {
        ShowFinishGameMenu();
        endGameScript.SetMessage("Ваши жизни кончились!");
    }

    public void GoToGame()
    {
        ShowGameMenu();
        startScript.InitiateGameSession();
    }

    public void GoToMainMenu()
    {
        ShowMainMenu();
    }

    public void GoToShop()
    {
        ShowShopMenu();
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
