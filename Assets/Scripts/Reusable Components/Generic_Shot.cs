using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Generic_Shot : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float duration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetUp(Vector2 shotDirection)
    {
        rb.velocity = shotDirection.normalized * speed;
    }

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
        Destroy(gameObject, duration);

    }

}
