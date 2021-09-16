using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header ("Movement Stuff")]
    public float speed;
    public Vector2 shotDirection;

    [Header("Lifecycle")]
    public float lifetime;
    private float lifetimeSeconds;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        lifetimeSeconds = lifetime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Shoot(Vector2 dir)
    {
        Debug.Log("Bang!");
        rb.velocity = speed * dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInChildren<Player_HealthNMagic>().Damage(15);
            other.GetComponentInParent<Player_Base>().KnockBack(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemies") || other.gameObject.CompareTag("DungeonArea"))
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
