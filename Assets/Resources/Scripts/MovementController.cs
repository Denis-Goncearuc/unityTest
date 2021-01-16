using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Transform _followPoint;
    private int Direction = 0;
    private Vector3 _rotationEuler;
    //private Rigidbody _rigidBody;
    //private CharacterController _characterController;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float rotationAmount = 0.5f;
    public float playerSpeed = 12f;

    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
    }

    // void Update()
    // {
    //     groundedPlayer = controller.isGrounded;
    //     if (groundedPlayer && playerVelocity.y < 0)
    //     {
    //         playerVelocity.y = 0f;
    //     }

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     controller.Move(move * Time.deltaTime * playerSpeed);

    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.right = move;
    //     }

    //     // Changes the height position of the player..
    //     if (Input.GetButtonDown("Jump") && groundedPlayer)
    //     {
    //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //     }

    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     controller.Move(playerVelocity * Time.deltaTime);
    // }
//}
     void Update()
    {
        if(Input.GetKey("a"))
            Direction = -1;
        else if(Input.GetKey("d"))
            Direction = 1;
        else
            Direction = 0;

        //if (Input.GetKey("s")) //&& groundedPlayer)
        //{
           //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}
        
        transform.position = Vector3.MoveTowards(transform.position, _followPoint.position,  playerSpeed * Time.deltaTime);
        
        _rotationEuler = new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationAmount * Direction, transform.localRotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(_rotationEuler);
        //transform.rotate (0, _rotationSpeed * Time.deltaTime, 0);
        
        // if (_characterController.isGrounded)
        // {
        //     // We are grounded, so recalculate
        //     // move direction directly from axes

        //     moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //     moveDirection *= speed;

        //     if (Input.GetButton("Jump"))
        //     {
        //         moveDirection.y = jumpSpeed;
        //     }
        // }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        //moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        //_characterController.Move(moveDirection * Time.deltaTime);
    }
}

//transform.localRotation = Quaternion.Euler(logic.newRotation);