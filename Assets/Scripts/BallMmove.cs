using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMmove : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;

    public  float axisDirecrtion = 1f;
    public  float ordinateDirection = 1f;
    private Transform transform;

    private AudioSource audioSource;
    public AudioClip border;
    public AudioClip hit;


    void Start()
    {
        transform= GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }
   
    private void isBorder()
    {
        if (transform.localPosition.y > 4.6f || transform.localPosition.y<-4.6f)
        {
            ordinateDirection = ordinateDirection == 1f ? -1f : 1f;
            audioSource.clip= border;
            audioSource.Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        axisDirecrtion = axisDirecrtion == 1f ? -1f : 1f;
        audioSource.clip = hit;
        audioSource.Play();
    }

    void FixedUpdate()
    {
        isBorder();
        Vector3 translation = new Vector3(axisDirecrtion * speed, ordinateDirection * speed,0) * Time.deltaTime;
        transform.Translate(translation);  
    }
}
