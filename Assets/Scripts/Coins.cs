using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Coins : MonoBehaviour
{
    private ScoreController scoreController;
    public string coinType;

    //Coin sounds
    private Sounds soundScript = new Sounds();
    [SerializeField]
    Sounds[] coinSounds;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            soundScript.PlayRandomSound(coinSounds);
            switch (coinType)
            {
                case "BronzeCoin":
                    scoreController.IncreaseScore(10);
                    break;
                case "SilverCoin":
                    scoreController.IncreaseScore(100);
                    break;
                case "GoldCoin":
                    scoreController.IncreaseScore(1000);
                    break;
            }
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coinType = this.gameObject.tag;
        scoreController = GameObject.Find("UI/UIScore").GetComponent<ScoreController>();
        soundScript.LoadSounds(coinSounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
