using System.Collections;
using UnityEngine;

public class Node1 : IHeapItem<Node1>
{

    public bool walkable;
    public Vector3 worldPosition;
    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;
    public int terrainPenalty;
    public Node1 parent;
    int heapIndex;

    public Node1(bool _walkable, Vector3 _worldPosition, int _gridX, int _gridY, int _penalty)
    {// void only to fix the error temporarily
        walkable = _walkable;
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
        terrainPenalty = _penalty;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }

    public int HeapIndex
    {
        get { return heapIndex; }
        set { heapIndex = value; }
    }

    public int CompareTo(Node1 nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;

    }
}
