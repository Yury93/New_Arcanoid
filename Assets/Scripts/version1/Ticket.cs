using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{
    [SerializeField] private Text textItem;
    [Header("Count str and columns")]
    [SerializeField] private int str = 24;

    [Header("Random item")]
    [SerializeField] private int randomMin;
    [SerializeField] private int randomMax;
    [Header("Inspector Dinamically")]
    [SerializeField]private List<int> item;
    public List<int> Items => item;
    
    void Awake()
    {
            for (int k = 0; k < str; k++)
            {
                
                item.Add(Random.Range(randomMin,randomMax));
            if (k != 0)
                {
                textItem.text += " " + item[k].ToString() + " ";
                }
            else
                {
                textItem.text += item[k].ToString() + " ";
                }
            }
    }
}
