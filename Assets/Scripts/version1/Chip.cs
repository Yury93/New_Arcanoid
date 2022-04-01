using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] private bool itemList;
    [SerializeField] private int index;
   
   
    public void SetIndex(int ind)
    {
        index = ind;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
