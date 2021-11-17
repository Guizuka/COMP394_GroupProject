using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text uiScore;
    private Score aScore;
    public string coinType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            switch(coinType)
            {
                case "BronzeCoin":
                    aScore.addScore(uiScore, 10);
                    break;
                case "SilverCoin":
                    aScore.addScore(uiScore, 100);
                    break;
                case "GoldCoin":
                    aScore.addScore(uiScore, 1000);
                    break;
            }
            
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coinType = this.gameObject.tag;
        uiScore = GameObject.Find("UI/UIScore").GetComponent<Text>();
        aScore = GameObject.Find("EventSystem").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
