using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    [SerializeField] private AudioSource wall,brick;
    
    public void PlayAudioBrick()
    {
        if(wall)
        wall.Play();
    }
    public void PlayAudioWall()
    {
        if(brick)
        brick.Play();
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
    public void StopAudio(AudioSource audio)
    {
        audio.Stop();
    }
}
