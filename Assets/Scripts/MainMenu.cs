using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene")]
    public string StartScene;
    public void OnClickQuit()
    {
        Application.Quit();
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene(StartScene);
    }

}
