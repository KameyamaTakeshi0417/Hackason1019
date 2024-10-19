using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;  // オーディオミキサーの参照

    // スライダーの参照
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider bgmSlider;
    public Slider systemSlider;

    void Start()
    {
        // スライダーの初期値を設定
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        systemSlider.value = PlayerPrefs.GetFloat("SystemVolume", 0.75f);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);  // デシベル変換
        PlayerPrefs.SetFloat("MasterVolume", volume);  // 設定を保存
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSystemVolume(float volume)
    {
        audioMixer.SetFloat("SystemVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SystemVolume", volume);
    }
}
