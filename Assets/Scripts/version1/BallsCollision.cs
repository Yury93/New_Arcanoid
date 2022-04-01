using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public Action OnCollisionBellsPlayer;
    private AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Brick>())
        {
            AudioManager.Instance.PlayAudioBrick();
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.Instance.PlayAudioWall();
        }
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlayAudio(audioSource);
            OnCollisionBellsPlayer?.Invoke();
            EffectManager managerEfFect = FindObjectOfType<EffectManager>();
            managerEfFect.ColisionPlatform(collision.gameObject.transform.position);
        }
    }
}
