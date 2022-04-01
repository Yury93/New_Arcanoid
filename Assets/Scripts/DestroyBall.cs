using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField] private GameObject spawnerBall;
    [SerializeField] private GameObject ball;
    [SerializeField] private float timeSpawn = 3f;
    [SerializeField] private EffectManager effectManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(CorSpawnBall());
            IEnumerator CorSpawnBall()
            {
                yield return new WaitForSeconds(timeSpawn);
                Instantiate(ball, spawnerBall.transform.position, Quaternion.identity);
                effectManager.SpawnBall(spawnerBall.transform.position);
            }
            Destroy(collision.gameObject);
        }
    }
    public void InstanceBall()
    {
       var b = Instantiate(ball, spawnerBall.transform.position, Quaternion.identity);
    }
}
