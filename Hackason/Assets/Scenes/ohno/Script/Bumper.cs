using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public ScoreManager scoreManager;  // ScoreManagerを参照
    private AudioSource audioSource;   // AudioSourceの参照

    void Start()
    {
        // バンパーのAudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))  // ボールがぶつかったら
        {
            scoreManager.AddScore(100);  // スコアに100点を追加
        }

        // 効果音を再生
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
    }
    // オブジェクトをクリックしたときに呼ばれるメソッド
    private void OnMouseDown()
    {
        scoreManager.AddScore(100);  // スコアに100点を追加
        // 効果音を再生
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        
    }
}
