using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{

    public AudioMixer Mixer;
    public void OnMasterVolumeChanged(float value)
    {
        Mixer.SetFloat("Master", value);
        AudioManager.MasterVolume = value;
    }

    public void OnMusicVolumeChanged(float value)
    {
        Mixer.SetFloat("Music", value);
        AudioManager.MusicVolume = value;
    }

    public void OnSfcVolumeChanged(float value)
    {
        Mixer.SetFloat("Sfc", value);
        AudioManager.SfcVolume = value;
    }
}
