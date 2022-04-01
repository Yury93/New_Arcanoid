using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speedMovement;
    [SerializeField] private Rigidbody2D rb;
    private GameObject ballsController;
    [Header("Settings AI")]
    [SerializeField] private bool ai;
    [SerializeField] private float timerState;
    [SerializeField] private float lerpT = 0.01f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       if(!ai)
        {
            if(joystick.Direction.x > 0)
            {
                rb.AddForce(Vector3.right * speedMovement * Time.deltaTime,ForceMode2D.Force);
                rb.drag = 0;
            }
            else if (joystick.Direction.x < 0)
            {
                rb.AddForce(Vector3.left * speedMovement * Time.deltaTime, ForceMode2D.Force);
                rb.drag = 0;
            }
            else
            {
                rb.AddForce(Vector3.zero);
                rb.drag = 2000000;
            }
        }
       else if(ai)
        {
            if(!ballsController)
            {
                ballsController = GameObject.Find("ModelAI");
            }
            else if(ballsController)
            {
                if (timerState > 0)
                {
                    timerState -= Time.deltaTime;
                    var vector = ballsController.transform.position;
                    var moveAi = new Vector3(ballsController.transform.position.x, transform.position.y, transform.position.z);
                    
                    transform.position = moveAi;
                }
                if(timerState < 0)
                {
                    if(lerpT == 0.01f)
                    {
                        StartCoroutine(CorTimerAiUpdate());
                    }
                    var vector = new Vector3(0, transform.position.y, transform.position.z);
                    var moveAi = Vector3.Lerp(transform.position, vector, lerpT + Time.deltaTime/4) ;
                    transform.position = moveAi;
                    
                }
            }
        }
    }

    IEnumerator CorTimerAiUpdate()
    {
        yield return new WaitForSeconds(2f);
        if (ballsController)
        {
            transform.DOMoveX(ballsController.transform.position.x, 1f);
        }
        else
        {
            ballsController = GameObject.Find("ModelAI");
            if (ballsController)
            {
                transform.DOMoveX(ballsController.transform.position.x, 1f);
            }
            else
            {
                StartCoroutine(CorTimerAiUpdate());
            }
        }
    }
}
