using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
   public AudioMixer audioMixer;
   public TMPro.TMP_Dropdown resolutionDropdown;
   private Resolution[] _resolutions;
   private void Start()
   {
      _resolutions =  Screen.resolutions;
      
      resolutionDropdown.ClearOptions();

      List<string> options = new List<string>();

      int currentResolutionIndex = 0;
      for (int i = 0; i < _resolutions.Length; i++)
      {
         String option = _resolutions[i].width + "x" + _resolutions[i].width;
         options.Add(option);

         if (_resolutions[i].width == Screen.currentResolution.width && 
             _resolutions[i].height == Screen.currentResolution.height)
         {
            currentResolutionIndex = i;
         }
      }

      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
   }

   public void SetResolution(int resolutionIndex)
   {
      Resolution resolution = _resolutions[resolutionIndex];
      Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
   }
   public void SetSfxVolume(float volume)
   {
      audioMixer.SetFloat("sfxVolume",volume);
   }
   public void SetMusicVolume(float volume)
   {
      audioMixer.SetFloat("musicVolume",volume);
   }
   
   public void SetQuality(int qualityIndex)
   {
      QualitySettings.SetQualityLevel(qualityIndex);
      
   }
   
   public void SetFullScreen(bool isFullScreen)
   {
      Screen.fullScreen = isFullScreen;
   }
   
}