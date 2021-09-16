using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : Base_Enemy
{

    public Transform[] path;
    public int currentPoint;
    public Transform nextPoint;
    public float roundingDistance = 0.2f;

    // Update is called once per frame
    void FixedUpdate()
    {//&& currentState != Enemy_State.die
        CheckDistance();
    }

    public override void CheckDistance()
    {
        if (Vector3.SqrMagnitude(target.position - transform.position) <= chaseRadius && Vector3.SqrMagnitude(target.position - transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                UpdateWalkingAnimation(temp);
            }
        }
        else
        {
            if (Vector3.SqrMagnitude(target.position - transform.position) > chaseRadius)
            {
                if (Vector3.SqrMagnitude(path[currentPoint].position - transform.position) > roundingDistance)
                {
                    Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, speed * Time.deltaTime);
                    rb.MovePosition(temp);
                    UpdateWalkingAnimation(temp);
                    currentState = EnemyState.walk;
                }
                else
                {
                    GoToNextPoint();
                }

            }

        }
    }

    public void GoToNextPoint()
    {
        if (path == null)
        {
            currentState = EnemyState.idle;
            GetComponent<Animator>().SetBool("isMoving", false);
        }
        else
        {
            if (currentPoint == path.Length - 1)
            {
                currentPoint = 0;
                nextPoint = path[0];
            }
            else
            {
                currentPoint++;
                nextPoint = path[currentPoint];
            }

        }
    }

    /*
    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public void UpdateWalkingAnimation(Vector3 directionInput)
    {
        Vector3 v = new Vector3(directionInput.x, directionInput.y, 0);
        Vector3 d = (v - transform.position);
        d.Normalize();
        anim.SetFloat("MoveX", d.x);
        anim.SetFloat("MoveY", d.y);
        anim.SetBool("isMoving", true);
    }

    public void UpdateWalkingAnimation(Vector2 directionInput)
    {
        Vector3 v = new Vector3(directionInput.x, directionInput.y, 0);
        Vector3 d = (v - transform.position);
        d.Normalize();
        anim.SetFloat("MoveX", d.x);
        anim.SetFloat("MoveY", d.y);
        anim.SetBool("isMoving", true);
    }
    */
}
