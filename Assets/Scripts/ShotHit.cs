using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Breakables"))
        {
     //       GetComponent<CinemachineImpulseSource>().GenerateImpulse();
       //     GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
            other.GetComponent<Break_Stuff>().Breaking();
        }
        if (other.CompareTag("Enemies"))
        {
            other.GetComponent<Base_Enemy>().ReduceHealt(1);
         //   GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
           // GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            other.GetComponent<Base_Enemy>().KnockBack();
        }
        Destroy(gameObject, 2f);

    }
}
