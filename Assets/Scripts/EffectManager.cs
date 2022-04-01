using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabSpawnBall;
    [SerializeField] private GameObject prefabDestroyBrick;
    [SerializeField] private GameObject prefabCollisionPlatform;
    public void SpawnBall(Vector3 pos)
    {
       var effect = Instantiate(prefabSpawnBall, pos, Quaternion.identity);
        Destroy(effect, 2f);
        
    }
    public void DestroyBrick(Vector3 pos)
    {
        var effect = Instantiate(prefabDestroyBrick, pos, Quaternion.identity);
        Destroy(effect, 2f);
    }
    public void ColisionPlatform(Vector3 pos)
    {
        var effect = Instantiate(prefabCollisionPlatform, pos, Quaternion.identity);
        Destroy(effect, 2f);
    }
}
