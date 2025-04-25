using UnityEngine;

[CreateAssetMenu(fileName = "AudioAssets", menuName = "Audio/Audio Assets")]
public class AudioAssets : ScriptableObject
{
    [Header("Music")]
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip resultsMusic;

    [Header("UI Sounds")]
    public AudioClip buttonClick;
    public AudioClip buttonHover;
    public AudioClip menuOpen;
    public AudioClip menuClose;

    [Header("Gameplay Sounds")]
    public AudioClip playerShoot;
    public AudioClip playerHit;
    public AudioClip playerDeath;
    public AudioClip enemyHit;
    public AudioClip enemyDeath;
    public AudioClip obstacleDestroyed;
    public AudioClip scoreIncrease;
}