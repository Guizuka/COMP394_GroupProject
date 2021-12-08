using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int scoreControl;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreControl = 0;
    }
    public void IncreaseScore(int value)
    {
        scoreControl += value;
        scoreText.text = "Score: " + scoreControl;
    }
}
