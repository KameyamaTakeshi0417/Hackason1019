using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   // スコアを表示するテキストUI
    private int score = 0;   // 現在のスコア

    // スコアを加算するメソッド
    public void AddScore(int points)
    {
        score += points;  // 指定されたポイントを加算
        UpdateScore();    // スコアを更新して表示
    }

    // スコアの表示を更新するメソッド
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
