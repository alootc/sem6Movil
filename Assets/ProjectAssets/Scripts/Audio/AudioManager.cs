using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioManager", menuName = "Audio/Audio Manager")]
public class AudioManager : ScriptableObject
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Volume Parameters")]
    [SerializeField] private string masterVolumeParam = "MasterVolume";
    [SerializeField] private string musicVolumeParam = "MusicVolume";
    [SerializeField] private string sfxVolumeParam = "SFXVolume";

    [Header("Default Volumes")]
    [Range(0f, 1f)][SerializeField] private float defaultMasterVolume = 0.8f;
    [Range(0f, 1f)][SerializeField] private float defaultMusicVolume = 0.7f;
    [Range(0f, 1f)][SerializeField] private float defaultSFXVolume = 0.9f;

    private const float MIN_VOLUME = -80f;
    private const float MAX_VOLUME = 0f;

    public void Initialize()
    {
        SetMasterVolume(defaultMasterVolume);
        SetMusicVolume(defaultMusicVolume);
        SetSFXVolume(defaultSFXVolume);
    }

    public void SetMasterVolume(float normalizedVolume)
    {
        SetVolume(masterVolumeParam, normalizedVolume);
        PlayerPrefs.SetFloat(masterVolumeParam, normalizedVolume);
    }

    public void SetMusicVolume(float normalizedVolume)
    {
        SetVolume(musicVolumeParam, normalizedVolume);
        PlayerPrefs.SetFloat(musicVolumeParam, normalizedVolume);
    }

    public void SetSFXVolume(float normalizedVolume)
    {
        SetVolume(sfxVolumeParam, normalizedVolume);
        PlayerPrefs.SetFloat(sfxVolumeParam, normalizedVolume);
    }

    private void SetVolume(string parameter, float normalizedVolume)
    {
        normalizedVolume = Mathf.Clamp01(normalizedVolume);
        float decibelVolume = MIN_VOLUME;

        if (normalizedVolume > 0.0001f) 
        {
            decibelVolume = 20f * Mathf.Log10(normalizedVolume);
            decibelVolume = Mathf.Clamp(decibelVolume, MIN_VOLUME, MAX_VOLUME);
        }

        audioMixer.SetFloat(parameter, decibelVolume);
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(masterVolumeParam, defaultMasterVolume);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolumeParam, defaultMusicVolume);
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(sfxVolumeParam, defaultSFXVolume);
    }
}