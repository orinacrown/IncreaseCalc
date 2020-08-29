using UnityEngine;
using System.Collections;

public class Score
{
    private static int score;
    public Score()
    {
        score = 0;
    }

    public static int CurrentScore()
    {
        return score;
    }

    public void Correct(int level)
    {
        score += level;
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
