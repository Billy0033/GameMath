using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;
    public GameObject Menu;

    private int levelToLoad = 1; // Переменная для хранения номера уровня

    public void Loading()
    {
        Menu.SetActive(false);
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
        /*int selectedLevel = 2; // Номер выбранного уровня
        GetComponent<LoadScreen>().SetLevelToLoad(selectedLevel);
        GetComponent<LoadScreen>().Loading();*/
    }

    public void SetLevelToLoad(int level)
    {
        levelToLoad = level;
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(levelToLoad);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;

            if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
