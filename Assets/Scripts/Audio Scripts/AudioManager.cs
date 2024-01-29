using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioModel backgroundMusic, bossMusic;
    [SerializeField] AudioModel[] sounds;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;
    Dictionary<string, AudioModel> dictionary;

    public static AudioModel currentClip;
    public static AudioManager instance = null;
    public static float musicVolume;
    public static float soundsVolume;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        InitializeManager();

        dictionary = new Dictionary<string, AudioModel>();
        foreach (var sound in sounds) dictionary[sound.index] = sound;
    }

    void InitializeManager()
    {
        musicVolume = PlayerPrefs.GetFloat("music", 0.5f);
        soundsVolume = PlayerPrefs.GetFloat("sounds", 0.5f);
        currentClip = instance.backgroundMusic;
        musicSource.clip = currentClip.clip;
        SaveSettings();
    }

    public static void SaveSettings()
    {
        PlayerPrefs.SetFloat("music", musicVolume);
        PlayerPrefs.SetFloat("sounds", soundsVolume);
        instance.SetVolume(); 
        PlayerPrefs.Save();
    }

    public void PlayMusic()
    {
        if (!musicSource.isPlaying) musicSource.Play();
    }

    public void PlaySound(string soundIndex)
    {
        if (soundsVolume > 0)
        {
            var sound = dictionary[soundIndex];
            soundSource.PlayOneShot(sound.clip, sound.volume * soundsVolume);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource.clip == bossMusic.clip) ChangeMusic();
        PlayMusic();
    }

    public void PlayBossMusic()
    {
        ChangeMusic();
        PlayMusic();
    }

    void ChangeMusic()
    {
        musicSource.Stop();
        currentClip = musicSource.clip == bossMusic.clip ? backgroundMusic : bossMusic;
        musicSource.clip = currentClip.clip;
        SetVolume();
    }

    void SetVolume() => musicSource.volume = currentClip.volume * musicVolume;
}
