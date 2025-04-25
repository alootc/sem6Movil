using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettingsUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private TMP_Text masterVolumeText;
    [SerializeField] private TMP_Text musicVolumeText;
    [SerializeField] private TMP_Text sfxVolumeText;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = Resources.Load<AudioManager>("Audio/AudioManager");
    }

    private void Start()
    {
        InitializeSliders();
    }

    private void InitializeSliders()
    {
        if (audioManager == null) return;

        
        masterVolumeSlider.value = audioManager.GetMasterVolume();
        musicVolumeSlider.value = audioManager.GetMusicVolume();
        sfxVolumeSlider.value = audioManager.GetSFXVolume();

        
        UpdateVolumeTexts();

        
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    private void OnMasterVolumeChanged(float value)
    {
        audioManager.SetMasterVolume(value);
        UpdateVolumeTexts();
    }

    private void OnMusicVolumeChanged(float value)
    {
        audioManager.SetMusicVolume(value);
        UpdateVolumeTexts();
    }

    private void OnSFXVolumeChanged(float value)
    {
        audioManager.SetSFXVolume(value);
        UpdateVolumeTexts();
    }

    private void UpdateVolumeTexts()
    {
        if (masterVolumeText != null)
            masterVolumeText.text = Mathf.RoundToInt(audioManager.GetMasterVolume() * 100) + "%";

        if (musicVolumeText != null)
            musicVolumeText.text = Mathf.RoundToInt(audioManager.GetMusicVolume() * 100) + "%";

        if (sfxVolumeText != null)
            sfxVolumeText.text = Mathf.RoundToInt(audioManager.GetSFXVolume() * 100) + "%";
    }
}