using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MusicClipOne;
    public AudioClip MusicClipTwo;
    public AudioSource MusicSource;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicSource.clip = MusicClipOne;
            MusicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            MusicSource.Stop();

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MusicSource.clip = MusicClipTwo;
            MusicSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            MusicSource.Stop();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            MusicSource.loop = true;
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            MusicSource.loop = false;
        }
    }
}
