using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketIndex : MonoBehaviour
{
    [SerializeField] private int index;
    public int Index => index;
    private Text textInd; 
    private void Awake()
    {
        index = Random.Range(10, 99);
        textInd = GetComponentInChildren<Text>();
        if (textInd)
        {
            textInd.text = index.ToString();
            textInd.color = Color.white;
        }
    }
    //public void ViewText()
    //{
    //    textInd.color = Color.black;
    //}
}
