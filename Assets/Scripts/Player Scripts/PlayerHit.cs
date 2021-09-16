using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerHit : MonoBehaviour
{
    
    [SerializeField] AudioClip[] hitSounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<Player_Base>().currentState == PlayerState.attack)
        {
            if (other.CompareTag("Player"))
            {

            }
            if (other.CompareTag("Breakables"))
            {
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
                GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
                other.GetComponent<Break_Stuff>().Breaking();
            }
            if (other.CompareTag("Enemies") && other.isTrigger)//I add isTrigger because enemies have 2 colliders, one actually for collisions and the other is a trigger to take damage
            {
                other.GetComponent<Base_Enemy>().ReduceHealt(1);
                GetComponent<AudioSource>().PlayOneShot(hitSounds[0]);
                Debug.Log("Dang!");
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
                other.GetComponent<Base_Enemy>().KnockBack();
            }
        }
    }



}
