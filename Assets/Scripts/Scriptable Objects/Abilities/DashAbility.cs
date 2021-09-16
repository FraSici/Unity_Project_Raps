using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Dash Ability", fileName = "Dash Ability")]
public class DashAbility : GenericAbility 
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 direction, Animator playerAnimator = null, Rigidbody2D playerRb = null)
    {
        base.Ability(playerPosition, direction, playerAnimator, playerRb);
        if (playerMagic.RuntimeValue <= magicCost)
        {
            playerMagic.RuntimeValue -= magicCost;
            usePlayerMagic.Raise();
        }
        else
        {
            return;
        }

        if (playerRb)
        {
            Vector3 dashVector = playerRb.transform.position + (Vector3)direction.normalized * dashForce;
            // some way to move playerRb (dashvector for duration)
        }
    }
    
    /*
        GetComponent<Player_Base>().currentState = PlayerState.dash;
        GetComponent<TrailRenderer>().enabled = true;
        yield return null;
        moveInput.Normalize();
        Vector2 dir = moveInput;
    myRigidBody.AddForce(dir* dashPush, ForceMode2D.Impulse);
//        audio.PlayOneShot(sounds[1]);
        yield return new WaitForSeconds(AttackTemplate.SetDuration(0.05f));
        myRigidBody.velocity = Vector2.zero;
        GetComponent<Player_Base>().currentState = PlayerState.walk;
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().Clear();
        */

}
