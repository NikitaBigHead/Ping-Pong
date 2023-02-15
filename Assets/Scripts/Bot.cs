using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Bot : MonoBehaviour
{
    
    public float speed = 20f;
    private Transform transform;
    private float lenBorder = 3.07f;//расстояние центральной точки ракетки до границы

    private float x;

    private bool up = false;//направления движения бота
    private bool down = false;

    public Transform ball;
    public BallMmove ballMmove;
    public float isHasBall = 0;

    public float height = 9.2f;

    private void processing()
    {
        if (ballMmove.axisDirecrtion == 1f)
        {
            int steps = getSteps(x, ball.transform.position.x);
            if (mathFunctionMoveBall(steps) < transform.position.y)
            {
                down = true;
                up = false;
            }
            else if (mathFunctionMoveBall(steps) >= transform.position.y)
            {
                up = true;
                down = false;
            }

        }
        else
        {
            if(transform.position.y<0)
            {
                up = true;
                down = false;
            }
            else
            {
                up = false;
                down = true;
            }
        }
    }
    private int getSteps(float x , float x1)
    {
        return Convert.ToInt32(Math.Abs( (x1 - x)) / ballMmove.speed) ;
    }
    private float mathFunctionMoveBall(int steps)
    {
        float y = 0;
        float ballY = ball.transform.position.y;

        float countDist = (steps * ballMmove.speed - ballY) / height; //кол-во пройденных высот -height // принадлежит отрузку от 0 до 1

        //при 0<=countDist<0.5 y убывает
        
        if (countDist % 2 >= 0 && countDist %2<0.5) { 
            y = ballY - countDist* height ;
        }
        //при 0.5<=countDist<1 y возрастает
        else if (countDist%2 >0.5 && countDist%2<1) 
        {
            y = ballY + countDist * height; 
        };
        Debug.Log(y);
        return y;
    }
    void Start()
    {
        transform = GetComponent<Transform>();
        x = transform.position.x; //
        
    }

    void Update()
    {
        processing();
        if (up)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
        else if (down)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime );
        }
        if (isHasBall == 1f)
        {
            ballMmove.ordinateDirection = 1f;
            ballMmove.speed = 20f;
            isHasBall = 0;
        }
    }
}
