using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerPrefab;

    private void Start()
    {
        //GameObject goGM = GameObject.Find("GameManager");
        //if(!goGM)
        //{
        //   var gm =  Instantiate(gameManagerPrefab, transform.position, Quaternion.identity);
        //    gm.GetComponent<GameManager>().DontDestr();
        //    gm.GetComponent<GameManager>().StartLevel();
        //}
    }
}
