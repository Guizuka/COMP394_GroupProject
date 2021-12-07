using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool WonLevel, PlayerDead = false;
    public CameraController cc;
    public LoopBackground lb;
    public GameObject LevelWonUI;
    public GameObject LevelLostUI;
    private void Start()
    {
        cc = FindObjectOfType<CameraController>();
        lb = FindObjectOfType<LoopBackground>();
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
    }
    public void LevelWon()
    {
        if (WonLevel)
        {
            StartCoroutine(ExecuteAfterTime(0.01f));
            LevelWonUI.SetActive(true);
        }
    }
    public void LevelLost()
    {
        if (PlayerDead)
        {
            StartCoroutine(ExecuteAfterTime(0.01f));
            LevelLostUI.SetActive(true);
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
        SceneManager.LoadScene("MainMenu");
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