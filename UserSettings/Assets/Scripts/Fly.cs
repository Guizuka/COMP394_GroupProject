using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private GameController gameControllerScript;
    void Awake()
    {
        gameControllerScript = FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<WizardScript>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
}