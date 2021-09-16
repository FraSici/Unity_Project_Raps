using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fall : MonoBehaviour
{
    Animator myAnimator;


    [SerializeField] private float timerMax = 4f;
    private float timer;
    [SerializeField] float fallDamage;
    

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("N_Walkable") && GetComponent<Player_Base>().currentState == PlayerState.dash)
        {
            /*Script falling ==> I need to:
              - Check the direction from which your are colliding
              - register the position before fall 
              - disable collider
              - animate fall
              -respawn on position before fall
              - take damage
               */
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("N_Walkable"))
        {
            //Timer();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        timer = 0;
    }

    private void Timer()
    {
        timer += Time.deltaTime;
        if(timer >= timerMax)
        {
            Vector2 initialPosition = gameObject.transform.position; //register position

            Vector2 dir = GetComponent<Player_Movement>().direction; //check direction
            dir.x = Mathf.Round(dir.x);
            dir.y = Mathf.Round(dir.y);
            
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false; //disable collider for animation

            myAnimator.SetBool("isMoving", false); //So that it won't move while the collider is disabled
            myAnimator.SetFloat("MoveX", dir.x);
            myAnimator.SetFloat("MoveY", dir.y);
            myAnimator.SetBool("isFalling", true); //Add boolean animating the falls;

            // /!\  ANIMATION EVENT similar to the one used for the second attack, pushing the player

            transform.position = initialPosition; //respawn player back to position before falling

            // /!\ flashing animation for damage + sound cue

            GetComponent<Player_HealthNMagic>().Damage(fallDamage);

            myAnimator.SetBool("isFalling", false); //Add boolean animating the falls;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true; //enable collider for animation


        }

    }
}
