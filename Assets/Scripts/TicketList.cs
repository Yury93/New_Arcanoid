using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketList : MonoBehaviour
{
    [SerializeField] private List<TicketIndex> tickets;
    [SerializeField] private List<int> index;
    private void Start()
    {
        for (int i = 0; i < tickets.Count; i++)
        {
            index[i] = tickets[i].Index;
        }
    }
}
