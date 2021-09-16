using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class PathFinding : MonoBehaviour
{

    //   public Transform seeker;
    //   public Transform target;
    PathRequestManager requestManager;
    Grid1 grid;

    private void Awake()
    {
        requestManager = GetComponent<PathRequestManager>();
        grid = GetComponent<Grid1>();
    }


    public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));

    }

    IEnumerator FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Vector3[] wayPoints = new Vector3[0];
        bool pathSuccess = false;
        Node1 startNode = grid.NodeFromWorldPoint(startPosition);
        Node1 targetNode = grid.NodeFromWorldPoint(targetPosition);

        if (startNode.walkable && targetNode.walkable)
        {
            Heap<Node1> openSet = new Heap<Node1>(grid.MaxSize);
            HashSet<Node1> closedSet = new HashSet<Node1>();
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                Node1 currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    sw.Stop();
                    print("Path found in: " + sw.ElapsedMilliseconds + " ms");
                    pathSuccess = true;
                    RetracePath(startNode, targetNode);
                    break;
                }

                foreach (Node1 neighbor in grid.GetNeighbors(currentNode))
                {
                    if (!neighbor.walkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor) + neighbor.terrainPenalty;
                    if (newMovementCostToNeighbor < currentNode.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newMovementCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                        else
                        {
                            openSet.UpdateItem(neighbor);
                        }
                    }
                }


            }

        }
        yield return null;
        if (pathSuccess)
        {
            wayPoints = RetracePath(startNode, targetNode);
            pathSuccess = wayPoints.Length > 0;
        }

        requestManager.FinishedProcessingPath(wayPoints, pathSuccess);
    }

    int GetDistance(Node1 nodeA, Node1 nodeB)
    {
        int distanceX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distanceY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }
        return 14 * distanceX + 10 * (distanceY - distanceX);
    }


    Vector3[] RetracePath(Node1 startNode, Node1 endNode)
    {
        List<Node1> path = new List<Node1>();
        Node1 currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        Vector3[] wayPoints = SimplifyPath(path);
        Array.Reverse(wayPoints);
        return wayPoints;

    }

    Vector3[] SimplifyPath(List<Node1> path)
    {
        List<Vector3> wayPoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                wayPoints.Add(path[i].worldPosition);
            }

            directionOld = directionNew;
        }

        return wayPoints.ToArray();
    }

}







