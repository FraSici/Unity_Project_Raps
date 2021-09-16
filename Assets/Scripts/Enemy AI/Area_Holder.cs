using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Holder : Patrolling
{

    public Collider2D areaBoundary;

    public override void CheckDistance()
    {
        if (Vector3.SqrMagnitude(target.position - transform.position) <= chaseRadius && Vector3.SqrMagnitude(target.position - transform.position) > attackRadius && areaBoundary.bounds.Contains(target.transform.position))
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
            if (Vector3.SqrMagnitude(target.position - transform.position) > chaseRadius || !areaBoundary.bounds.Contains(target.transform.position))
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

}
