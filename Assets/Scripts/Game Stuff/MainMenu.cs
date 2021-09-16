using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    public void NewGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quick2Desktop()
    {
        Application.Quit();
    }
}
