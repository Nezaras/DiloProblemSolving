using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;

    public void IncreaseScore(int value)
    {
        ScoreText.text = $"Score {(score += value)}";
    }
}
