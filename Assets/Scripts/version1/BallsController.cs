using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbBalls;
    [SerializeField] private float direction,minSpeed,maxSpeed;
    private BallsCollision ballsCollision;
    [SerializeField] private bool ai;

    void Start()
    {
        if (!ai)
        {
            rbBalls = GetComponentInChildren<Rigidbody2D>();
            rbBalls.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(minSpeed, maxSpeed));
            ballsCollision = GetComponentInChildren<BallsCollision>();
            ballsCollision.OnCollisionBellsPlayer += CollisionDetected;
        }
        if(ai)
        {
            rbBalls = GetComponentInChildren<Rigidbody2D>();
            rbBalls.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(-minSpeed, -maxSpeed));
            ballsCollision = GetComponentInChildren<BallsCollision>();
            ballsCollision.OnCollisionBellsPlayer += CollisionDetected;
        }
    }
   
    private void CollisionDetected()
    {
        if (!ai)
        {
            rbBalls.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(minSpeed, maxSpeed));

        }
        if(ai)
        {
            rbBalls.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(-minSpeed, -maxSpeed));
        }
    }
}
