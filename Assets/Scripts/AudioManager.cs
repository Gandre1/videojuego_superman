using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip introSound;

    void Start()
    {
        PlayMusic();
        PlayIntroSound();
    }

    void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    void PlayIntroSound()
    {
        sfxSource.PlayOneShot(introSound);
    }
}