using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipList : MonoBehaviour
{
    [SerializeField] private List<Chip> chips;
    private Ticket ticket;
  
    private void Start()
    {
        ticket = FindObjectOfType<Ticket>();

        for (int i = 0; i < chips.Count; i++)
        {
            chips[i].SetIndex(ticket.Items[i]);
        }
    }
}
