using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBot : MonoBehaviour
{
    public BallMmove ballMmove;
    public float speed = 20f;
    public float isHasBall = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < ballMmove.transform.position.y)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
        else if (transform.position.y >= ballMmove.transform.position.y)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        }
        if (isHasBall == 1f)
        {
            ballMmove.ordinateDirection = 1f;
            ballMmove.speed = 20f;
            isHasBall = 0;
        }
    }

}
