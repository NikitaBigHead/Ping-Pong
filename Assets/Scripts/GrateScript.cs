using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrateScript : MonoBehaviour
{
    public Transform ball;
    public Transform player;
    public PlayerMove playerScript;
    public BallMmove ballScript;
    public Text textScrore;
    public int score = 0;

    private float x; //кординаты м€ча, после гола
    private float y;
    private float sign; // знак X у м€ча
    private float ballDist = 0.5f;

    private EasyBot bot;
    public GameObject playerObject;

    private AudioSource audioSource;
    public AudioClip goal;
    void Start()
    {
        sign = player.transform.position.x>0 ? 1 : -1;
        if (playerScript == null) bot = playerObject.GetComponent<EasyBot>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.clip = goal;
        audioSource.Play();

        score++;
        x = player.transform.position.x - sign * ballDist;
        y = player.transform.position.y;

        ball.transform.position =  new Vector3(x, y);
        if (playerScript != null) { playerScript.isHasBall = 1; }//присваем м€ч
        else if(playerScript == null)
        {
            bot.isHasBall = 1f;
        }

        ballScript.speed = 0;
        textScrore.text = score.ToString();


    }

}
