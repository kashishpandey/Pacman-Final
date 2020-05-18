using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;


    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;

    }
   
 
    void Update()
    {
        scoreText.text = "Score: " + (int)scoreAmount ;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }
}
