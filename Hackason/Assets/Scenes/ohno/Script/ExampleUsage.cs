using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public AudioManager audioManager; // AudioManagerの参照
    public AudioClip flipRaiseSound; // フリッパーを上げた時
    public AudioClip flipLowerSound; // フリッパーを下げた時
    public AudioClip collisionSound; // オブジェクトに衝突したとき
    public AudioClip plungerSound; // プランジャーを押した時

    void Update()
    {
        // AボタンまたはDボタンが押されたとき
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) 
        {
            audioManager.PlaySFX(flipRaiseSound); // 効果音を再生
        }

        // AボタンまたはDボタンが離されたとき
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            audioManager.PlaySFX(flipLowerSound); // 効果音を再生
        }
        
        // スペースボタンが押されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.PlaySFX(plungerSound); // 効果音を再生
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // オブジェクトに衝突したとき
        audioManager.PlaySFX(collisionSound); // 効果音を再生
    }
}
