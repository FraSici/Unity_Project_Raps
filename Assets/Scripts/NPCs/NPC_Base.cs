using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Base : Object_Message
{

    private Vector3 directionVector;
    private Transform myTransform;
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public Collider2D boundaries;

    public float minMoveTime;
    public float maxMoveTime;
    private float moveTime;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        moveTime = Random.Range(minMoveTime, maxMoveTime);
        waitTime = Random.Range(minWaitTime, maxWaitTime);
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (anim.GetBool("isMoving"))
        {
            moveTime -= Time.deltaTime;
            if (moveTime <= 0)
            {
                moveTime = Random.Range(minMoveTime, maxMoveTime);
                anim.SetBool("isMoving", false);
                NewDirection();
            }
            if (!playerInRange)
            {
                MoveNPC();
            }
        }else
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                anim.SetBool("isMoving", true);
                waitTime = Random.Range(minWaitTime, maxWaitTime);
            }
        }
    }

    private void NewDirection()
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    private void MoveNPC()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (boundaries.bounds.Contains(temp))
        {
            rb.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                directionVector = Vector2.right;
                break;
            case 1:
                directionVector = Vector2.up;
                break;
            case 2:
                directionVector = Vector2.left;
                break;
            case 3:
                directionVector = Vector2.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        NewDirection();
    }

}
