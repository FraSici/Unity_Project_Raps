using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    const float pathUpdateMoveThreshold = 1f;
    const float minPathUpdateDTime = 0.5f;

    public Transform target;
    public float speed;
    public Rigidbody2D rb;
    Vector3[] path;
    int targetIndex;
    [SerializeField] bool targetReached = false;

    public float turnDist = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine(FollowPath());
            StartCoroutine(FollowPath());
        }
    }

    public IEnumerator UpdatePath()
    {
        if (targetReached)
        {
            yield break;
        }

        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);

        float sqrMoveTreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
        Vector3 targetOldPos = target.position;

        while (true)
        {
            yield return new WaitForSeconds(minPathUpdateDTime);
            if ((target.position - targetOldPos).sqrMagnitude > sqrMoveTreshold)
            {
                PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
                targetOldPos = target.position;
            }

        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWayPoint = path[0];

        while (true)
        {
            if (transform.position == currentWayPoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWayPoint = path[targetIndex];
            }

            if (Vector3.SqrMagnitude(currentWayPoint - transform.position) <= 0.5f && currentWayPoint == path[path.Length - 1])
            {
                rb.velocity = Vector2.zero;
                Debug.Log("Stop following");
                targetReached = true;
                GetComponent<Animator>().SetBool("isMoving", false);
                yield break;
            }
            else
            {
                targetReached = false;
                Vector2 temp = Vector2.MoveTowards(transform.position, currentWayPoint, speed * Time.deltaTime);
                rb.MovePosition(temp);
                //GetComponent<Dummy_Enemy>().UpdateWalkingAnimation(temp);
                yield return null;
            }
                
        }
    }

    /* ************************************************************************************************
     ********************************GIZMOS************************************************************
     ************************************************************************************************** */
    private void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
