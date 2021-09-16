using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Tuning : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public IEnumerator Animation_MoveHorizontal(float push)
    {
        
        Vector2 forceDirection = new Vector2(push, 0f);

        myRigidBody.AddForce(forceDirection);
        yield return new WaitForSecondsRealtime(0.15f);
        myRigidBody.velocity = Vector2.zero;
        

        /*
        Vector2 direction = new Vector2(push, 0f);
        myRigidBody.MovePosition(myRigidBody.position + direction);
        yield return null;*/
    }

    public IEnumerator Animation_MoveVertical(float push)
    {
        Vector2 forceDirection = new Vector2(0f , push);

        myRigidBody.AddForce(forceDirection);
        yield return new WaitForSecondsRealtime(0.15f);
        myRigidBody.velocity = Vector2.zero;
    }


}
