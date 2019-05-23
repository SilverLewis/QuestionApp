using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Questions");
    }
    public void AddPlayer()
    {
        SceneManager.LoadScene("Add Player");
    }
    public void Settings()
    {
        print("does not exist yet");
    }
    public void Instructions()
    {
        print("does not exist yet");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void FrontPage() {
        SceneManager.LoadScene("Front Page");
    }
}
