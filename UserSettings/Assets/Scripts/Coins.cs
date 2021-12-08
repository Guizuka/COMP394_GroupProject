using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Coins : MonoBehaviour
{
    [SerializeField]
    ScoreController scoreController;
    public string coinType;
    [SerializeField]
    private int coinValue;

    //Coin sounds
    private Sounds soundScript = new Sounds();
    [SerializeField]
    Sounds[] coinSounds;

    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("UI/UIScore").GetComponent<ScoreController>();
        soundScript.LoadSounds(coinSounds);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            soundScript.PlayRandomSound(coinSounds);
            switch (coinType)
            {
                case "Bronze":
                    scoreController.IncreaseScore(coinValue);
                    break;
                case "Silver":
                    scoreController.IncreaseScore(coinValue);
                    break;
                case "Gold":
                    scoreController.IncreaseScore(coinValue);
                    break;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
