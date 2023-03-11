using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource footstepSound;
  

    //for player variable
    public float currentMoveSpeed;
    public float moveSpeed;
    public Vector3 velocity;
    public float currentWalkAnimationSpeed;
    public float walkAnimationSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public float runSpeed;
    public float runAnimationSpeed;

    //for player component
    private Rigidbody rb_Player;
    private Animator an_Player;
    //for other GameObjects

    public GameObject cameraObj;
    public GameObject playerMesh;
    // from google
    public bool isGrounded;
    //own code
    SwordDamage swordDamage;

    // Awake is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        rb_Player = GetComponent<Rigidbody>();
        an_Player = GetComponent<Animator>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //check if player in the ground  and if player in the ground will enable landing to move fall



        //check if top arrow and bottom arrow  or left and right arrow are pressed.. if pressed by keyboard move player
        if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
        {
            //move player
            MovePLayer(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            footstepSound.enabled = true;
        }
        else {
            footstepSound.enabled = false;
        }


        if (isGrounded)
        { //click space to jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        //left click in the mouse to attack
        if (Input.GetMouseButtonDown(0))
        {
            Attack();

        }
        //press left shift to run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunUp();
        }


    }


    //Move Function for move player
    public void MovePLayer(float forward,float right)
    {
        //forward parameter mean virtical axis from keyboard, right parameter mean horizontal axis from keyboard
        //Get Vertical axis and horizontal axis and multiple to camera vertical axis and horizontal axis

        Vector3 translation;


        translation = forward * cameraObj.transform.forward;
        translation += right * cameraObj.transform.right;
        translation.y = 0;

        //check if vertical and horizontal is pressed

        if (translation.magnitude > 0.2f)
        {
            //set velocity to equal to translation
            velocity = translation;
           
        }
        else
        {
            //set velocity to zero
            velocity = Vector3.zero;
           
        }
        
        //Move PLayer By Rigid body velocity
        rb_Player.velocity = new Vector3(velocity.normalized.x * moveSpeed, rb_Player.velocity.y, velocity.normalized.z * moveSpeed);

        // Rotate Player
        if (velocity.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.Lerp(playerMesh.transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);

        }
        
        //Move Animation
        an_Player.SetFloat("Velocity", velocity.magnitude * walkAnimationSpeed);
    }

    //start jump function
    public void Jump()
    {
        //jump by rigid body
        rb_Player.AddForce(Vector3.up * jumpForce);

        //play animation
       an_Player.SetTrigger("Jump");
    }

    //check if ground 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "item")
        {
            isGrounded = true;
        }
    }



    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    //end checking 


    //end jump function
    //start attack function
    public void Attack()
    {
        Cursor.visible = false;

        float randomNumber = Random.Range(0, 15);
        if (randomNumber >= 0 && randomNumber <= 0)
        {
            an_Player.SetTrigger("Attack1");
        }
        else if (randomNumber > 5 && randomNumber <= 10)
        {
            an_Player.SetTrigger("Attack2");
        }
        else if (randomNumber > 5 && randomNumber <= 15)
        {
            an_Player.SetTrigger("Attack3");
        }


       
    }
    //end attack funtion
    //start of death function

    public void Death()
    {
        an_Player.SetTrigger("Death");
        Cursor.visible = true;

    }
    //end death

    public void RunDown()
    {
        moveSpeed = runSpeed;
        walkAnimationSpeed = runAnimationSpeed;
    }
    public void RunUp()
    {
        moveSpeed = currentMoveSpeed;
        walkAnimationSpeed = currentWalkAnimationSpeed;
    }
}
