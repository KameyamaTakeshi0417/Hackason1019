using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXVolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;  // AudioMixerの参照
    public Slider soundEffectSlider;  // 効果音のスライダー

    void Start()
    {
        // スライダーの初期値を設定
        soundEffectSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume", 1f); // デフォルトは1（最大音量）

        // スライダーの変更イベントにメソッドを登録
        soundEffectSlider.onValueChanged.AddListener(SetSoundEffectVolume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        // スライダーの値をデシベルに変換し、AudioMixerに設定
        audioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundEffectVolume", volume); // 音量を保存
    }
}
