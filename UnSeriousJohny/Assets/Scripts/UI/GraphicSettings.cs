using System;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    private Vector2[] Resolutions =
    {
        new Vector2(1920,1080),
        new Vector2(1680,1050),
        new Vector2(1600,900),
        new Vector2(1440,900),
        new Vector2(1366,768),
        new Vector2(1360,768),
        new Vector2(1280,800),
        new Vector2(1280,768),
        new Vector2(1280,720),
        new Vector2(1280,600),
        new Vector2(640,400), 
    };

    public Dropdown ResolutionDropdown;
    public Toggle FullScreen;
    public Toggle Shadows;
    public Slider Quality;
    public Slider Brightness;
    private bool fullscreen;
    private bool shadows;

    
    void Save()
    {
        PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(FullScreen.isOn));
        PlayerPrefs.SetInt("Shadows", Convert.ToInt32(Shadows.isOn));
        PlayerPrefs.SetFloat("Quality", Quality.value);
        PlayerPrefs.SetFloat("Brightness", Brightness.value);
    }

    void Load()
    {
        ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        FullScreen.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen"));
        Shadows.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Shadows"));
        Quality.value = PlayerPrefs.GetFloat("Quality");
        Brightness.value = PlayerPrefs.GetFloat("Brightness");
    }
    void Start()
    {
        string[] resolutionStrings = new string[Resolutions.Length + 1];
        for (int i = 0; i < Resolutions.Length; i++)
        {
            resolutionStrings[i] = Resolutions[i].x + "x" + Resolutions[i].y;
        }
        resolutionStrings[resolutionStrings.Length - 1] = Screen.width + "x" + Screen.height;
        ResolutionDropdown.AddOptions(resolutionStrings.ToList());
        ResolutionDropdown.value = resolutionStrings.Length - 1;
        Load();
    }

    public void OnFullscreenClicked()
    {
        if (fullscreen)
        {
            fullscreen = false;
            Screen.fullScreen = false;
        }
        else
        {
            fullscreen = true;
            Screen.fullScreen = true;
        }
        Save();
    }

    public void OnResolutionChanged(int value)
    {
        FixText();
        Screen.SetResolution(Convert.ToInt32(Resolutions[value].x),Convert.ToInt32(Resolutions[value].y),fullscreen);
        Save();
    }

    public void OnShadowsClicked()
    {
        shadows = !shadows;
        //ToDo Implement Shadows
        Save();
    }

    public void OnQualityChanged(float value)
    {
        int intValue = Convert.ToInt32(value);
        QualitySettings.SetQualityLevel(intValue);
        Save();
    }

    public void OnBrightnessChanged(float value)
    {
        //ToDo Implement Brightness
        Save();
    }

    private void FixText()
    {
        foreach (var fontEqalizer in GameObject.FindObjectsOfType<FontEqalizer>())
        {
            fontEqalizer.ResizeText();
        }
    }
}
