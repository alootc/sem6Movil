using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private bool playOnAwake = false;
    [SerializeField] private bool isMusic = false;
    [SerializeField] private AudioClip[] clips;

    private AudioSource audioSource;
    private AudioManager audioManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = Resources.Load<AudioManager>("Audio/AudioManager");

        if (playOnAwake && clips.Length > 0)
        {
            PlayRandom();
        }
    }

    public void PlayRandom()
    {
        if (clips.Length == 0) return;

        int randomIndex = Random.Range(0, clips.Length);
        Play(clips[randomIndex]);
    }

    public void Play(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    private void Update()
    {
        if (audioManager != null)
        {
            audioSource.volume = isMusic ?
                audioManager.GetMusicVolume() :
                audioManager.GetSFXVolume();
        }
    }
}