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
        SceneManager.LoadScene("DifficultySelectorMenu");
    }
    public void Option()
    {
        SceneManager.LoadScene("Option");
    }
    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }
    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
