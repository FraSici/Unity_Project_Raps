using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
       // if (GetComponent<Player_Base>().currentState == PlayerState.attack)
        //{
            if (other.CompareTag("Player"))
            {
                if (other.GetComponentInParent<Player_Base>().currentState != PlayerState.stagger)
                {
                   other.GetComponentInChildren<Player_HealthNMagic>().Damage(10);
                    other.GetComponentInParent<Player_Base>().KnockBack(this.gameObject);
                }
            }
            if (other.CompareTag("Breakables"))
            {
                //other.GetComponent<Break_Stuff>().Breaking();
            }
            if (other.CompareTag("Enemies"))
            {

            }
        //}
    }
}