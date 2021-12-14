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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<WizardScript>().TakeDamage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if(other.tag == "Bolt")
        {
            Destroy(this.gameObject);
        }
    }
}