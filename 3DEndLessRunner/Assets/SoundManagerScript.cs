using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip pacmanWalkSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        pacmanWalkSound = Resources.Load<AudioClip>("pacman_chomp");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "pacman_chomp":
                audioSrc.PlayOneShot(pacmanWalkSound);
                break;
        }
    }
 } 
