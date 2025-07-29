using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementLogic : MonoBehaviour
{
    public float launchSpeed = 5f;
    private Rigidbody2D rb; 
    private Vector2 initialPosition; 
    private SpriteRenderer sr;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sr = GetComponent<SpriteRenderer>(); 
        initialPosition = gameObject.transform.position; //save the init pos for the relaunches
        LaunchBall();
    }
   
    void Update()
    {
        
    }

    void LaunchBall()
    {
        float randomX = UnityEngine.Random.Range(-1f, 1f); 
        Vector2 direction = new Vector2(randomX, -1).normalized;
        rb.velocity = direction * launchSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("LosingZone"))
        {
            Debug.Log("The Ball has fallen into the losing zone...");

            StartCoroutine(StopAndRelaunch());
        }

    }

    IEnumerator StopAndRelaunch()
    {
       
        rb.velocity = Vector2.zero;
        //  gameObject.SetActive(false); //THIS APPROACH STOPS THE COROUTINE AND EVERYTHING AFTER, INSTEAD USE SPRITERENDERER
        sr.enabled = false; 

        GameManager.Instance.LoseLife(); 

        yield return new WaitForSeconds(1f);

        if (GameManager.Instance.lives > 0 && !GameManager.Instance.isGameOver)
        {
            sr.enabled = true;
            transform.position = initialPosition;
            gameObject.SetActive(true);
            LaunchBall();
        }
        else
        {
            gameObject.SetActive(false); 
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlockBehavior block = collision.gameObject.GetComponent<BlockBehavior>();

        if (block != null)
        {
            block.TakeDamage(1);
        }
        
    }
}