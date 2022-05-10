using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static AudioSource Ass;
    public AudioClip startmusic;
    public static AudioClip MapMusic;

    private void Start()
    {
        MapMusic = startmusic;
        Ass = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public static void ChangeMusic(AudioClip music)
    {
        if (Ass.clip != music)
        {
            Ass.clip = music;
            Ass.Play();
        }
    }
}
