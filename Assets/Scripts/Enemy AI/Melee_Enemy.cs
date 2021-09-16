using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Enemy : Base_Enemy
{
    private void FixedUpdate()
    {
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
        else if (Vector3.SqrMagnitude(target.position - transform.position) <= chaseRadius && Vector3.SqrMagnitude(target.position - transform.position) <= attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

    public IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("isMoving", false);
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.walk;
        anim.SetBool("isAttacking", false);
        anim.SetBool("isMoving", true);
    }

}
