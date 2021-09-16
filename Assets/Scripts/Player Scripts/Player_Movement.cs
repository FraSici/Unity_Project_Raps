using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.InputSystem;

/*
 This script will handle the basic player movements i.e. walking and dashing.
 In a later phase there can also be something like running and charging, or 
 maybe they could be split up in other classes
     */


public class Player_Movement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    
    //Movement parameters
    [SerializeField] float moveSpeed = 3f; // use [serfiel] or public in order to have something that you can modify from Unity UI
    public Vector2 moveInput;
    private bool isMoving;//Implementing the state machine and the *blend trees*, you need only to define one bool for all animations of a kind (eg walking anims)



    //dash parameters

    [SerializeField] float dashTimeMax = 1f;
    [SerializeField] float dashTime = 0;
    [SerializeField] float dashPush = 0.001f;
    [SerializeField] float dashSpeed = 10f;

    [Header("Input System")]
    [SerializeField] public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
       
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("MoveX", 0);//If i do not set a default values for these, if player attacks without moving first, all colliders will activate and will hit all around him
        myAnimator.SetFloat("MoveY", -1);
    }

    // Update is called once per frame
    void Update()
    {

        if(GetComponent<Player_Base>().currentState == PlayerState.walk)
        {
            if(direction != Vector2.zero)
            {
                Move();
            }
            AnimatorOnMove();
        }

        /*moveInput = Vector2.zero;
        //getaxis and getaxisraw register the input of the axes and outputs +1 or -1 according to the axis direction
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        */
    }
    private void GetMoveInput(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

    }

    public void Move()
    {
        myRigidBody.MovePosition(myRigidBody.position + direction * moveSpeed * Time.deltaTime);
    }
    public void AnimatorOnMove()
    {
        /*need to use the rounding so that when i move diagonally the blend trees do 
         not mix the features of the different animations, which in the case of attacks
         would be activating 2 hitboxes at once*/
        if (direction == Vector2.zero)
        {
            myAnimator.SetBool("isMoving", false);
            myAnimator.SetFloat("MoveX", 0);
            myAnimator.SetFloat("MoveY", 0);
        }
        else
        {
            direction.x = Mathf.Round(direction.x);
            direction.y = Mathf.Round(direction.y);
            myAnimator.SetFloat("MoveX", direction.x);
            myAnimator.SetFloat("MoveY", direction.y);
            myAnimator.SetBool("isMoving", true);

        }
    }

    public IEnumerator Dashing()//Need to fix when player is not moving
    {
        Transform dashPosition = gameObject.transform;
        GetComponent<Player_Base>().currentState = PlayerState.dash;
        Transform dashStart = dashPosition;
        Debug.Log("Starting position: " + dashPosition.position);
        
        GetComponent<TrailRenderer>().enabled = true;
        yield return null;
        direction.Normalize();
        Vector2 dir = direction;
        myRigidBody.AddForce(dir * dashPush, ForceMode2D.Impulse);
        //        audio.PlayOneShot(sounds[1]);
        
        yield return new WaitForSeconds(AttackTemplate.SetDuration(0.05f));
        myRigidBody.velocity = Vector2.zero;
        GetComponent<Player_Base>().currentState = PlayerState.walk;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().Clear();

        Transform dashFinish = gameObject.transform;
        Debug.Log("Final position: " + dashFinish.position);

    }
    /*public void Move()
    {
        moveInput.Normalize();
        myRigidBody.MovePosition(myRigidBody.position + moveInput * moveSpeed * Time.deltaTime);
        //If i want to work with the velocity vector: i have to use rb.velocity, not just taking the xplatinput times movespeed
    }*/
    /*
    public void AnimatorOnMove()
    {
        //need to use the rounding so that when i move diagonally the blend trees do 
         //not mix the features of the different animations, which in the case of attacks
         //would be activating 2 hitboxes at once
        moveInput.x = Mathf.Round(moveInput.x);
        moveInput.y = Mathf.Round(moveInput.y);
        myAnimator.SetFloat("MoveX", moveInput.x);
        myAnimator.SetFloat("MoveY", moveInput.y);
        myAnimator.SetBool("isMoving", true);
    }
*/

    /*public IEnumerator Dashing()//Need to fix when player is not moving
    {
        GetComponent<Player_Base>().currentState = PlayerState.dash;
        GetComponent<TrailRenderer>().enabled = true;
        yield return null;
        moveInput.Normalize();
        Vector2 dir = moveInput;
        myRigidBody.AddForce(dir * dashPush, ForceMode2D.Impulse);
//        audio.PlayOneShot(sounds[1]);
        yield return new WaitForSeconds(AttackTemplate.SetDuration(0.05f));
        myRigidBody.velocity = Vector2.zero;
        GetComponent<Player_Base>().currentState = PlayerState.walk;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().Clear();

    }
    */

}
