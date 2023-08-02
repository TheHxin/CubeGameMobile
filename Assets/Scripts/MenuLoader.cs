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
