using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyScene : MonoBehaviour
{
    public GameObject player2;
    public GameObject Gate2;
    public BallMmove ball;
    private void Awake()
    {

        if(DataScene.countPlayer== 1)
        {
            player2.AddComponent<EasyBot>();
            EasyBot settings = player2.GetComponent<EasyBot>();

            settings.speed = 20f;
            settings.isHasBall = 0;
            settings.ballMmove = ball;


        }
        else if(DataScene.countPlayer== 2)
        {
            player2.AddComponent<PlayerMove>();
            PlayerMove settings = player2.GetComponent<PlayerMove>();

            settings.speed = 20;
            settings.upButton = KeyCode.O;
            settings.downButton = KeyCode.L;
            settings.isHasBall = 0;
            settings.ballMmove = ball;

            Gate2.GetComponent<GrateScript>().playerScript = settings;
        }
    }
}
