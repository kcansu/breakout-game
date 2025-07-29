using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMove();
    }

    void PaddleMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime); 

        float clampedX = Mathf.Clamp(transform.position.x, -7.9f, 7.9f); //TODO: min,max variable to change
        transform.position = new Vector3(clampedX, transform.position.y, 0); 



    }

}
