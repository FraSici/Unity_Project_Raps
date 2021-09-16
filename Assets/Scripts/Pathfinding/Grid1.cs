using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid1 : MonoBehaviour
{

    public bool displayGridGizmos;
    public Transform player;
    public LayerMask unwalkableMask;

    public Tilemap hardTerrain;
    public int hardTerrainPenalty = 2000;

    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node1[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    public TerrainType[] walkableRegions;
    LayerMask walkableMask;
    Dictionary<int, int> walkableRegionsDictionary = new Dictionary<int, int>();

    private void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        foreach (TerrainType region in walkableRegions)
        {
            walkableMask.value |= region.terrainMask.value; // | is the bitwise OR operation, I could have simplified by writing " --- |= ---; "
            walkableRegionsDictionary.Add((int)Mathf.Log(region.terrainMask.value, 2), region.terrainPenalty);
        }

        CreateGrid();

    }

    public int MaxSize
    {
        get { return gridSizeX * gridSizeY; }
    }

    void CreateGrid()
    {
        grid = new Node1[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapCircle(new Vector2(worldPoint.x, worldPoint.y), nodeRadius, unwalkableMask));

                int terrainPenalty = 0;

                if (walkable)
                {

                    if (Physics2D.OverlapPoint(new Vector2(worldPoint.x, worldPoint.y), walkableMask))/*TODO: there may be a problem when there are 
                        multiple layers and penalties, in that case maybe it would be better to use overlapAll in order to get all the colliders and then filter based 
                        on priority (most penalizing layer before others)*/
                    {
                        
                        LayerMask newLayer = Physics2D.OverlapPoint(new Vector2(worldPoint.x, worldPoint.y), walkableMask).gameObject.layer;
                        walkableRegionsDictionary.TryGetValue(newLayer, out terrainPenalty );
                    }
                }
                grid[x, y] = new Node1(walkable, worldPoint, x, y, terrainPenalty);
            }            
        }

 //       BlurPenaltyMap(3); This gives an "array index out of bounds problem"
    }


    /*BUILT IN BUT NOT IMPLEMENTED*/
    void BlurPenaltyMap(int blurSize)
    {
        int kernelSize = blurSize * 2 + 1;
        int kernelExtents = (kernelSize - 1) / 2;

        int[,] penaltiesHorizontalPass = new int[gridSizeX, gridSizeY];
        int[,] penaltiesVerticalPass = new int[gridSizeX, gridSizeY];

        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = - kernelExtents; x <= kernelExtents; x++)
            {
                int sampleX = Mathf.Clamp(x, 0, kernelExtents);
                penaltiesHorizontalPass[0, y] += grid[sampleX, y].terrainPenalty;
            }
            for (int x = 1; x < gridSizeX; x++)
            {
                int removeIndex = Mathf.Clamp(x - kernelExtents - 1, 0, gridSizeX);
                int addIndex = Mathf.Clamp(x + kernelExtents, 0, gridSizeX - 1);

                penaltiesHorizontalPass[x, y] = penaltiesHorizontalPass[x - 1, y] - grid[removeIndex, y].terrainPenalty + grid[addIndex, y].terrainPenalty;
            }
        }

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = -kernelExtents; y <= kernelExtents; y++)
            {
                int sampleY = Mathf.Clamp(y, 0, kernelExtents);
                penaltiesVerticalPass[x, 0] += penaltiesHorizontalPass[x, sampleY];
            }
            for (int y = 1; y < gridSizeY; y++)
            {
                int removeIndex = Mathf.Clamp(x - kernelExtents - 1, 0, gridSizeY);
                int addIndex = Mathf.Clamp(x + kernelExtents, 0, gridSizeY - 1);

                penaltiesVerticalPass[x, y] = penaltiesVerticalPass[x, y - 1] - penaltiesHorizontalPass[x, removeIndex] + penaltiesHorizontalPass[x, addIndex];
                int blurredPenalty = Mathf.RoundToInt((float)penaltiesVerticalPass[x, y] / (kernelSize * kernelSize));
                grid[x, y].terrainPenalty = blurredPenalty;
            }
        }
    }

    public List<Node1> GetNeighbors(Node1 node)
    {
        List<Node1> neighbors = new List<Node1>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbors.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }

    public Node1 NodeFromWorldPoint(Vector3 worldPosition)
    {

        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.back * 10, Vector3.forward * 10);
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));
        if (grid != null && displayGridGizmos)
        {
            Node1 playerNode = NodeFromWorldPoint(player.position);
            foreach (Node1 n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red; //amazing short hand to do fast if then else
                if (n == playerNode)
                {
                    Gizmos.color = Color.cyan;
                }

                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));

            }
        }
    }

    [System.Serializable]
    public class TerrainType
    {
        public LayerMask terrainMask;
        public int terrainPenalty;
    }

}
