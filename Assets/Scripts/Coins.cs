using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text uiScore;
    private ScoreController scoreController;
    public string coinType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            switch(coinType)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
