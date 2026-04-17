using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip menuMusic;

    void Start()
    {
        musicSource.clip = menuMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
}