using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ExitMenu;
    public GameObject ShopMenu;


    public void ButtonExit()
    {
        MainMenu.gameObject.SetActive(false);
        ExitMenu.gameObject.SetActive(true);
       
    }
    public void ButtonExitNo()
    {
        MainMenu.gameObject.SetActive(true);
        ExitMenu.gameObject.SetActive(false);
    }

    public void ButtonExitYes(){ Application.Quit(); }

    public void ButtonStart(){
        MainMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(1);

    }
    public void ButtonShop()
    {
        MainMenu.gameObject.SetActive(false);
        ShopMenu.gameObject.SetActive(true);
    }
    public void BackButtonShop()
    {
        MainMenu.gameObject.SetActive(true);
        ShopMenu.gameObject.SetActive(false);
    }
}
