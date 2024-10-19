using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;          // AudioSourceの参照
    public AudioClip pressSound;              // ボタン押下時の効果音
    public AudioClip releaseSound;            // ボタン離した時の効果音

    void Start()
    {
        // AudioSourceが未指定の場合、同じGameObjectにあるAudioSourceを取得
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // AまたはDボタンが押されたとき
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            PlayPressSound();
        }
        
        // AまたはDボタンが離されたとき
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            PlayReleaseSound();
        }
    }

    // ボタン押下時の効果音を再生
    void PlayPressSound()
    {
        audioSource.PlayOneShot(pressSound);
    }

    // ボタン離した時の効果音を再生
    void PlayReleaseSound()
    {
        audioSource.PlayOneShot(releaseSound);
    }
}
