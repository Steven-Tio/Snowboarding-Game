using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D[] surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectsOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            RotatePlayer();
            GravityShift();
            RespondToBoost();
        }

    }

    public void DisableControls(){
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D[0].speed = boostSpeed;
        }
        else{
            surfaceEffector2D[0].speed = baseSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D[1].speed = boostSpeed;
        }
        else{
            surfaceEffector2D[1].speed = baseSpeed;
        }
    }

    void GravityShift()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.gravityScale = 3;
        }
        else if (rb2d.gravityScale > 1)
        {
            rb2d.gravityScale = 1;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
    }
}
