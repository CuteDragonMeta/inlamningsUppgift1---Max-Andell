using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RunSpeed;
    public float MoveSmoothTime;
    public float JumpStreagth;
    public float GravityStrengh;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;
    private Vector3 CurrentForceVelocity;
    public static Vector3 startPosition;

    public void Awake(){
        startPosition = transform.position; // defines start position with the coordinates at the stat of the game
    }
    void Start()
    {
        Controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {

        Vector3 PlayerInput = new Vector3 {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };

        if (PlayerInput.magnitude > 1f){
            PlayerInput.Normalize(); // Makes this vector have a magnitude of 1.
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MovementSpeed; // Sprint or walk

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDampVelocity,
            MoveSmoothTime
        );
        
        Controller.Move(CurrentMoveVelocity * Time.deltaTime);  //Move player

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        //Checks if Player is allowed to jump
        if (Physics.Raycast(groundCheckRay, 0.1f) && Input.GetKey(KeyCode.Space)){
            CurrentForceVelocity.y = JumpStreagth;
        }else{
            CurrentForceVelocity.y -= GravityStrengh * Time.deltaTime;
        }

        Controller.Move(CurrentForceVelocity*Time.deltaTime);    // Move player

    }

}

