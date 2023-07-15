using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void WinMenu()
    {
        SceneManager.LoadScene("WinMenu");
    }
    public void LoseMenu()
    {
        SceneManager.LoadScene("LoseMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Option()
    {
        SceneManager.LoadScene("Option");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
