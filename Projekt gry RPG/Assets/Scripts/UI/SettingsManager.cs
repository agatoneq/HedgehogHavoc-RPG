using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown ResolutionDropdown;

    public Resolution[] resolutions;
    public static Resolution chosenResolution;
    public static bool isPicked = false;
    public static bool FullScreenEnabled = false;
    public static int currentResolutionIndex ;

    void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int ResolutionIndex = 0;

        UnityEngine.Debug.Log("res0 set to" + chosenResolution);
        ResolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                ResolutionIndex = i;

            }

        }


        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
        if (isPicked)
            Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled);
        else
        {
            chosenResolution = resolutions[resolutions.Length - 1];
            Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled=true);
            isPicked = true;
            UnityEngine.Debug.Log("default res set to: " + chosenResolution);
        }


    }

    public void SetVolume(float volume)
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

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        resolutionIndex = ResolutionDropdown.value;
        currentResolutionIndex = resolutionIndex;
        isPicked = true;
        chosenResolution = resolutions[currentResolutionIndex];

        UnityEngine.Debug.Log("res1 set to" + chosenResolution);
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, Screen.fullScreen);

        UnityEngine.Debug.Log("index: " + currentResolutionIndex);
    }
    public static void SetResolution()
    {
        if (isPicked)
        {
            UnityEngine.Debug.Log("res2 set to" + chosenResolution);
            Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled);
        }

    }
}
