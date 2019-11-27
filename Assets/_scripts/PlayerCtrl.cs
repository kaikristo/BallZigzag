using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject startPosition;

    [SerializeField]
    float speed = 10f;

    float clickDelay = 0.1f;
    float timeElapsed = 0f;

    private UICtrl uiCtrl;

    private Direction direction = Direction.Forward;

    private void Start()
    {
        uiCtrl = UICtrl.instance;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {

            if (GameCtrl.instance.GameStatus == GameStatus.IsStop)
            {               
                GameCtrl.instance.WaitAndStart();
                transform.position = startPosition.transform.position;
                if (uiCtrl != null) uiCtrl.HideLoseWindow();
            }
            else
            {
                if (timeElapsed >= clickDelay)
                {
                    timeElapsed = 0;
                    if (direction == Direction.Forward)
                    {
                        direction = Direction.Rigth;
                    }
                    else
                    {
                        direction = Direction.Forward;
                    }
                }

            }
        }
        if (GameCtrl.instance.GameStatus == GameStatus.IsRunning)
        {
           
            if (IsDead())
            {
                Death();
                return;
            }
            float distance = speed * Time.deltaTime;

            if (direction == Direction.Forward)
            {
                gameObject.transform.Translate(0, 0, distance);
            }
            else
                if (direction == Direction.Rigth)
            {
                gameObject.transform.Translate(distance, 0, 0);
            }
            
        }




        timeElapsed += Time.deltaTime;
    }

    private void Death()
    {
        GameCtrl.instance.GameStatus = GameStatus.IsStop;
        if (uiCtrl != null) uiCtrl.ShowLoseWindow();
    }

    private bool IsDead()
    {
        float DisstanceToTheGround = 1f;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);
        return !isGrounded;

    }
}
