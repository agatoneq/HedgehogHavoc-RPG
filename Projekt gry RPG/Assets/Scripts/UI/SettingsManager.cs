using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public  class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown ResolutionDropdown;

    public  Resolution[] resolutions;
    public static Resolution chosenResolution;
    public static bool isPicked=false;
    public static bool FullScreenEnabled=false;
    public static int currentResolutionIndex = 0;

    void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

=======
        UnityEngine.Debug.Log("res0 set to" + chosenResolution);
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

>>>>>>> Stashed changes
        for (int i=0; i<resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;

            }

        }


        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
        if(isPicked)
            Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled);

    }

    public void SetVolume (float volume)
    {
        //audioMixer.SetFloat("volume", volume);
        AudioManager.Instance.SFXSource.volume = volume;
        AudioManager.Instance.musicSource.volume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        UnityEngine.Debug.Log("Setting quality to index: " + qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex, false);

    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
