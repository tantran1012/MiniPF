using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingUI : MonoBehaviour
{
    public GameObject GameSettingUI;
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Slider musicSlider;
    public Slider soundSlider;

    Resolution [] resolutions;
    float temp;
    void Start() {
        audioMixer.GetFloat("music",out temp);
        musicSlider.value = temp;
        audioMixer.GetFloat("sound", out temp);
        soundSlider.value = temp;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void onShow() {
        GameSettingUI.SetActive(true);
    }
    
    public void onClose() {
        GameSettingUI.SetActive(false);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("music", volume);
    }

    public void SetSound(float volume) {
        audioMixer.SetFloat("sound", volume);
    }

    public void SetQuality(int quality) {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool fullscreen) {
        Screen.fullScreen = fullscreen;
    }

    public void SetResolutionIndex(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
