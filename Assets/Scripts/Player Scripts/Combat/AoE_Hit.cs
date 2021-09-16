using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class AoE_Hit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioClip[] hitSounds;
    // Update is called once per frame
    
    //The following works perfectly, just modifying it to see if the tagging works
    /*  private void OnTriggerEnter2D(Collider2D other)
      {
          if (other.CompareTag("Breakables"))
          {
              GetComponent<CinemachineImpulseSource>().GenerateImpulse();
              GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
              other.GetComponent<Break_Stuff>().Breaking();
          }
          if (other.CompareTag("Enemies"))
          {
              other.GetComponent<Enemy_Base>().ReduceHealt(3);
              GetComponent<CinemachineImpulseSource>().GenerateImpulse();
              other.GetComponent<Enemy_Base>().KnockBack();
          }

      }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You're not supposed to be hit");
        }
        if (other.CompareTag("Breakables"))
        {
            GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
            other.GetComponent<Break_Stuff>().Breaking();
        }
        if (other.CompareTag("Enemies"))
        {
            player.GetComponent<ShootScript>().AddToMarked(other.gameObject);
            Debug.Log("Enemy Marked? " + other.GetComponent<Base_Enemy>().Marked);
        }
    }

    
}
