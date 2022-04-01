using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlatform : MonoBehaviour
{
    private void Start()
    {
        Visible(false);   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Visible(false);
        }
    }
   
    public void Visible(bool visible)
    {
        gameObject.GetComponent<Collider2D>().enabled = visible;
        gameObject.GetComponent<SpriteRenderer>().enabled = visible;
    }
}
