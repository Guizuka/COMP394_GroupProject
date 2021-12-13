using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void EasyMode()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }
    public void MediumMode()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
    }
    public void HardMode()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
