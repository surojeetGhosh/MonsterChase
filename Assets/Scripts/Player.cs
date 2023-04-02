using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Serialize Field is used to access private variables on inspect menu in unity
    [SerializeField]
    private float moveForce= 10;
    [SerializeField]
    private float jumpForce= 11;
    private float movementX;
    private Rigidbody2D body;
    private SpriteRenderer ren;
    private Animator anim;
    
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        ren = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        playerMovementX();
        animatePlayer();
        playerJump();
        
    }

    // it is used when we want to do task in certain time
    // void FixedUpdate()
    // {
        
    // }

    void playerMovementX() {
        // GetAxis slowly goes from 0 -> 1 [-1, 1] range including all real numbers
        // GetAxisRaw directly goes from 0 -> 1 [-1, 0, 1]
        // this value represent where we are going in each frame + represent toward + axis
        movementX = Input.GetAxisRaw("Horizontal");
        // Time.deltaTime represents the amount of time it took from rendering last from to coming to present frame
        // if we do not multiply this value then in each frame our player will move by 10 units in each frame which when multiplying
        // with 24 fps is 24*10 = 240 units per second which will huge, so to make it normalize with speed of frame we multiply
        // it with Time.deltaTime
        // this makes movements speed similar in each specs of pcs
        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
    }

    // GetButton() returns true for button to be down 
    // GetButtonDown() returns true only when button is pressed down not hold 
    // GetButtonUp() returns true when button is pressed up 
    void playerJump() {
        // change scale of gravity depending on what you want
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            // impulse type of force is used
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // this is called when our object is collided
    // whichever object you are detecting collision with name it under same tag
    // for this Ground tag is used
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
        if(other.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
    // they are three ways to slip a player
    /*
        first using transform.rotation
        second using transform.scale
        third using sprite renderer flip option
    */
    /*
        in animator you can select a transition and go to transition duration set it to 0 and speed depending on how fast u
        want animation.
        transition duration leads to certain amount of time take to transition from one state to another but it doesn't
        show animation
    */

    // this is for ghost as ghost can pass through we have it as not solid
    //so when ghost touches it will trigger
    // runs whenever it is triggered
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
    void animatePlayer() {
        // setting boolean condition to true or false which we created for player animation
        if(!isGrounded) {
            anim.SetBool(JUMP_ANIMATION, true);
        } else {
            anim.SetBool(JUMP_ANIMATION, false);
        }
        if(movementX > 0) {
            // walking in right direction
            anim.SetBool(WALK_ANIMATION, true);
            ren.flipX = false;
        } else if(movementX < 0) {
            // walking in left direction
            anim.SetBool(WALK_ANIMATION, true);
            ren.flipX= true;
        } else {
            // idle
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
