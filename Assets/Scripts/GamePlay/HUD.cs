using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static int score = 0;
    static int ballsLeft = 5;

    Text scoreText;
    Text ballsLeftText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
        ballsLeftText.text = "Balls Left : " + ballsLeft;
    }

    public static void updateScoreTexts(float point)
    {
        score += (int)point;
    }

    public static void updateBallsLeftText()
    {
        ballsLeft -= 1;
    }
}
