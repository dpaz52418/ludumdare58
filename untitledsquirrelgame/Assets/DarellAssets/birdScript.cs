using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
           myRigidbody.linearVelocity = Vector2.up * flapStrength; 
        }
        
    }
}
