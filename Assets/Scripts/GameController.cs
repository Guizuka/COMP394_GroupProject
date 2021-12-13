using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool WonLevel, PlayerDead = false;
    private bool timePause = false;
    public CameraController cc;
    public LoopBackground lb;
    public GameObject LevelWonUI;
    public Text realScore;
    public Text stars;
    public GameObject LevelLostUI;
    public GameObject pauseMenuUI;
    private void Start()
    {
        cc = FindObjectOfType<CameraController>();
        lb = FindObjectOfType<LoopBackground>();
        WonLevel = false;
        PlayerDead = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        //If they beat the level and press n, go to next level
        if (WonLevel && Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }
        //If they beat level and press r, restart level
        if (WonLevel && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        //If they died and press r, restart level
        if (PlayerDead && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        //If they died and press m, go to main menu
        if (PlayerDead && Input.GetKeyDown(KeyCode.M))
        {
            MainMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        timePause = !timePause;
        if (timePause)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void LevelWon()
    {
        if (WonLevel)
        {
            StartCoroutine(ExecuteAfterTime(0.01f));
            LevelWonUI.SetActive(true);
            Calculate();
        }
    }
    public void Calculate()
    {
        realScore.text = ScoreController.scoreControl.ToString();
        if(ScoreController.scoreControl <= 7500)
        {
            stars.text = "This earned you 1 star";
        }
        if (ScoreController.scoreControl > 7500 && ScoreController.scoreControl <= 20000)
        {
            stars.text = "This earned you 2 stars";
        }
        if (ScoreController.scoreControl > 20000)
        {
            stars.text = "This earned you 3 stars";
        }
    }
    public void LevelLost()
    {
        if (PlayerDead)
        {
            StartCoroutine(ExecuteAfterTime(0.01f));
            LevelLostUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void NextLevel()
    {
        //Proceed to the next level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        //Restart the level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        //Load Main Menu
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    //Enumerator used to stop time after player lost, exactly 1.01 seconds after player won.
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        cc.horizontalSpeed = 0f;
        lb.backgroundSpeed = 0f;
    }
}