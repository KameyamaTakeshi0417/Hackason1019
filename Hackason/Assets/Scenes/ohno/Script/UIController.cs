using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenuUI;  // ポーズ画面のUIを表示/非表示にするためのオブジェクト

    private bool isPaused = false;  // ポーズ状態を管理

    void Start()
    {
        // 初期起動時にポーズ画面を非表示に設定
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // ESCキーが押されたらポーズのオン/オフを切り替える
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // ポーズ解除
            }
            else
            {
                Pause();  // ポーズ
            }
        }
    }

    // ポーズ解除
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // ポーズ画面を非表示
        Time.timeScale = 1f;           // 時間を通常通り進行
        isPaused = false;
    }

    // ポーズ
    void Pause()
    {
        pauseMenuUI.SetActive(true);   // ポーズ画面を表示
        Time.timeScale = 0f;           // 時間を停止
        isPaused = true;
    }

    // ゲーム終了（メニューからのオプションとして）
    public void QuitGame()
    {
        Application.Quit();  // ゲームを終了
    }
}
