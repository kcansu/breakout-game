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
    public AudioClip mainMenuSFX;
    public AudioClip gameSFX;
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
       //ADD SCENE AND START MUSIC
    }

   //ADD SCENE & PLAY SFX FUNTIONS
}
