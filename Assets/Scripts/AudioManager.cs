using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip buttonPressSFX;
    public AudioClip failSFX;
    public AudioClip gameOverSFX;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += newSceneLoaded;
    }

   public void newSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainMenu")
        {
            PlayMusic(mainMenuMusic);   
        }
        else if (scene.name == "GameScene")
        {
            PlayMusic(gameMusic);
        }
    }
 //TODO: add click sfx
   public void PlayMusic(AudioClip music)
    {
        if (musicSource.isPlaying) musicSource.Stop();

        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfx)
    {
        sfxSource.clip = sfx;
        sfxSource.Play();
    }
}
