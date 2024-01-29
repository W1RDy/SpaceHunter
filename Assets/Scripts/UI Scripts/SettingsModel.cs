using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsModel : MonoBehaviour
{
    [SerializeField] Slider musicSlider, soundsSlider;
    [SerializeField] Toggle hintToggle; 
    [SerializeField] HintModel hintModel;

    void Start()
    {
        musicSlider.value = AudioManager.musicVolume;
        soundsSlider.value = AudioManager.soundsVolume;
        hintToggle.isOn = hintModel.isHint;
    }

    public void ChangeMusicVolume()
    {
        AudioManager.musicVolume = musicSlider.value;
        AudioManager.SaveSettings();
    }

    public void ChangeSoundsVolume()
    {
        AudioManager.soundsVolume = soundsSlider.value;
        AudioManager.SaveSettings();
    }
    public void ChangeHints()
    {
        if (hintToggle.isOn !=  hintModel.isHint)
        {
            hintModel.ChangeHintsAvailable();
            hintModel.SaveSettings();
        }
    }
}
