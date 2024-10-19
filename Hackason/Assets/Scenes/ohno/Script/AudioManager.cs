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

    public AudioSource sfxSource; // 効果音用のAudioSource
    public AudioSource buttonClickSource; // 効果音用のAudioSource
    

    void Start()
    {
        // スライダーの初期値を設定
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        systemSlider.value = PlayerPrefs.GetFloat("SystemVolume", 0.75f);

        // 初期値を反映するために、スライダーの値を即座に適用
        SetMasterVolume(masterSlider.value);
        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);
        SetSystemVolume(systemSlider.value);

        // スライダーにリスナーを追加
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        systemSlider.onValueChanged.AddListener(SetSystemVolume);
    }

    public void SetMasterVolume(float volume)
    {
        if (volume == 0)
    {
        audioMixer.SetFloat("MasterVolume", -80f);  // 無音に設定
    }
    else
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);  // デシベル変換
    }
        PlayerPrefs.SetFloat("MasterVolume", volume);  // 設定を保存
    }

    public void SetSFXVolume(float volume)
    {
         if (volume == 0)
    {
        audioMixer.SetFloat("SFXVolume", -80f);  // 無音に設定
    }
    else
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetBGMVolume(float volume)
    {
        if (volume == 0)
    {
        audioMixer.SetFloat("BGMVolume", -80f);  // 無音に設定
    }
    else
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSystemVolume(float volume)
    {
        if (volume == 0)
    {
        audioMixer.SetFloat("SFXVolume", -80f);  // 無音に設定
    }
    else
    {
        audioMixer.SetFloat("SystemVolume", Mathf.Log10(volume) * 20);
    }
        PlayerPrefs.SetFloat("SystemVolume", volume);
    }

    // 効果音を再生するメソッド
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip); // AudioClipを一時的に再生
    }

    //ボタンクリック時の効果音を再生する
    public void PlayButtonClickSound(AudioClip clip)
    {
        buttonClickSource.PlayOneShot(clip);
    }
}
