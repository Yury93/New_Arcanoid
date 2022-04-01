using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Scale platform")]
    [SerializeField] private GameObject platform;
    [SerializeField] private bool ai;

    [SerializeField] private DestroyBall destroyBall;
    [SerializeField] private DestroyBall destroyBall1;
    private Rigidbody2D rb;
    [SerializeField] private GameObject secondPlatform,secondPlatformAI;
    private int random;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        if (!ai)
        {
            platform = GameObject.Find("Player");
            destroyBall = GameObject.Find("Destroyer1").GetComponent<DestroyBall>();
            secondPlatform = GameObject.Find("SecondPlatform");
            secondPlatformAI = GameObject.Find("SecondPlatformAI");
            rb.gravityScale = 0.3f;

        }
        if(ai)
        {
            secondPlatformAI = GameObject.Find("SecondPlatformAI");
            secondPlatform = GameObject.Find("SecondPlatform");
            rb.gravityScale = -0.3f;
            platform = GameObject.Find("Ai");
            destroyBall1 = GameObject.Find("Destroyer1 (1)").GetComponent<DestroyBall>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        random = Random.Range(1, 4);
        if(collision.gameObject.CompareTag("Player"))
        {
            if (ai)
            {
                if (random == 1)
                {
                    ScalePlatform(platform);
                }
                else if (random == 2)
                {
                    ScalePlatform(platform);
                }
                else if (random == 3)
                {
                    ViewSecondPlatform();
                }
                Destroy(gameObject);
            }
            if (!ai)
            {
                if (random == 1)
                {
                    ScalePlatform(platform);
                }
                else if (random == 2)
                {
                    SecondBall();
                }
                else if (random == 3)
                {
                    ViewSecondPlatform();
                }
                Destroy(gameObject);
            }
        }
    }


    public void SecondBall()
    {
        destroyBall.InstanceBall();
    }
    public void ScalePlatform(GameObject platformSet)
    {
        platformSet.transform.localScale = new Vector3(platformSet.transform.localScale.x * 2,
            platformSet.transform.localScale.y, platformSet.transform.localScale.z);
        StartCoroutine(CorScale());
        IEnumerator CorScale()
        {
            yield return new WaitForSeconds(5f);
            platformSet.transform.localScale = new Vector3(platformSet.transform.localScale.x / 2,
            platformSet.transform.localScale.y, platformSet.transform.localScale.z);
        }
    }
    public void ViewSecondPlatform()
    {
        if (!ai)
        {
            secondPlatform.GetComponent<SecondPlatform>().Visible(true);
            StartCoroutine(CorDisble());
            IEnumerator CorDisble()
            {
                yield return new WaitForSeconds(10f);
                secondPlatform.GetComponent<SecondPlatform>().Visible(false);
            }
        }
        if(ai)
        {
            secondPlatformAI.GetComponent<SecondPlatform>().Visible(true);
            StartCoroutine(CorDisble());
            IEnumerator CorDisble()
            {
                yield return new WaitForSeconds(10f);
                secondPlatformAI.GetComponent<SecondPlatform>().Visible(false);
            }
        }
    }
    public void SetAiMode(bool boolAi)
    {
        ai = boolAi;
    }
}
