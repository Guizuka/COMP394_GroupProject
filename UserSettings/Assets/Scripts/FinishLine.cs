using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<WizardScript>().anim.SetTrigger("LineCrossed");
            gc.WonLevel = true;
            gc.LevelWon();
        }
    }

}
