using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int scoreControl;
    // Start is called before the first frame update
    void Start()
    {
        scoreControl = 0;
    }

    public void IncreaseScore(int value)
    {
        scoreControl += value;
        gameObject.GetComponent<Text>().text = scoreControl.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
