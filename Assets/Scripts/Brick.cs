using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private Text textIndex;
    [SerializeField] private TicketIndex ticket;
    [SerializeField] private bool ai,  bonus;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private bool empty;
    private EffectManager effector;
    [SerializeField] private bool indestruct;

    public void Start()
    {
        if (!empty)
        {
            textIndex = GetComponentInChildren<Text>();
            if (textIndex)
            {
                index = ticket.Index;
                textIndex.text = index.ToString();
            }
        }
        effector = GameObject.Find("EffectManager").GetComponent<EffectManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!empty)
        {
            if (!bonus)
            {
                if (collision.gameObject.tag == "Ball")
                {
                    effector.DestroyBrick(transform.position);
                    if (!indestruct)
                    {
                        Destroy(gameObject, 0.1f);
                    }
                    ticket.gameObject.GetComponentInChildren<Text>().color = Color.black;
                }
                if (collision.gameObject.CompareTag("Ball") && ai)
                {
                    effector.DestroyBrick(transform.position);
                    if (!indestruct)
                    {
                        Destroy(gameObject, 0.1f);
                    }
                    ticket.gameObject.GetComponentInChildren<Text>().color = Color.red;
                }
            }
            else if (bonus && collision.gameObject.CompareTag("Ball"))
            {
                if (ai)
                {
                    var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
                    bonus.GetComponent<PowerUp>().SetAiMode(true);
                    ticket.gameObject.GetComponentInChildren<Text>().color = Color.red;
                    effector.DestroyBrick(transform.position);
                    if (!indestruct)
                    {
                        Destroy(gameObject, 0.1f);
                    }
                }
                else if (!ai)
                {
                    var bonus = Instantiate(bonusPrefab, transform.position, Quaternion.identity);
                    bonus.GetComponent<PowerUp>().SetAiMode(false);
                    ticket.gameObject.GetComponentInChildren<Text>().color = Color.black;
                    effector.DestroyBrick(transform.position);
                    if (!indestruct)
                    {
                        Destroy(gameObject, 0.1f);
                    }
                }
            }
            if (collision.gameObject.tag == "Ball")
            {
                if (gameObject.GetComponentInParent<BrickList>())
                    gameObject.GetComponentInParent<BrickList>().RemoveBrick();
            }
        }
        else
        {
            effector.DestroyBrick(transform.position);
            if (!indestruct)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
