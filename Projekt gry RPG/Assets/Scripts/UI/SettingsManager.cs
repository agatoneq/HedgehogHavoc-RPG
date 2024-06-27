using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Player;

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
<<<<<<< Updated upstream
        
        
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = Player.Instance.currentResolutionId;

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
<<<<<<< Updated upstream
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Player.Instance.currentResolution = resolution;
    Player.Instance.currentResolutionId = resolutionIndex;
=======
        resolutionIndex = ResolutionDropdown.value;
        isPicked = true;
        UnityEngine.Debug.Log("res1 set to" + chosenResolution);
        chosenResolution = resolutions[resolutionIndex];
        Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled);
        UnityEngine.Debug.Log("index: " + resolutionIndex);
    }
    public static void SetResolution()
    {
        if (isPicked)
        {
            UnityEngine.Debug.Log("res2 set to" + chosenResolution);
            Screen.SetResolution(chosenResolution.width, chosenResolution.height, FullScreenEnabled);
        }
>>>>>>> Stashed changes
    }

}
