using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public KeyCode upButton;
    public KeyCode downButton;
    public float speed = 20f;

    private Transform transform;
    private float lenBorder = 3.07f;//расстояние центральной точки ракетки до границы

    public BallMmove ballMmove;
    public float isHasBall = 0;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    private float isBorderUp()
    {
        if (transform.localPosition.y > lenBorder)
        {
            return 0;
        }
        return 1;
    }
    private float isBorderDown()
    {
        if (transform.localPosition.y < -lenBorder)
        {
            return 0;
        }
        return 1;
    }

    private void Update()
    {

        if (Input.GetKey(upButton))
        {
            if(isHasBall == 1f) {
                ballMmove.ordinateDirection = 1f * isHasBall;
                ballMmove.speed = 20f;
                isHasBall = 0;
            }

            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime * isBorderUp());
        }
        else if (Input.GetKey(downButton)) {
            if (isHasBall == 1f)
            {
                ballMmove.ordinateDirection = -1f * isHasBall;
                ballMmove.speed = 20f;
                isHasBall = 0;
            }

            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime * isBorderDown());
        }
    }
}



