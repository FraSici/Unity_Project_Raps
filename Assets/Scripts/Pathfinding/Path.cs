using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*BUILT IN BUT NOT IMPLEMENTED*/
public class Path
{

    public readonly Vector3[] lookPoints;
    public readonly Line[] turnBoundaries;
    public readonly int finishLineIndex;

    public Path(Vector3[] waypoints, Vector3 startPos, float turnDist)
    {
        lookPoints = waypoints;
        turnBoundaries = new Line[lookPoints.Length];
        finishLineIndex = turnBoundaries.Length - 1;

        Vector2 previousPoint = V3toV2(startPos);
        for (int i = 0; i < lookPoints.Length; i++)
        {
            Vector2 currentPoint = V3toV2(lookPoints[i]);
            Vector2 dirToCurrentPoint = (currentPoint + previousPoint).normalized;
            Vector2 turnBoundaryPoint = (i == finishLineIndex)?currentPoint: currentPoint - dirToCurrentPoint * turnDist;
            turnBoundaries[i] = new Line(turnBoundaryPoint, previousPoint - dirToCurrentPoint * turnDist);
            previousPoint = turnBoundaryPoint;
        }
    }

    Vector2 V3toV2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }

    public void DrawWithGizmos()
    {
        Gizmos.color = Color.black;
        foreach (Vector3 p in lookPoints)
        {
            Gizmos.DrawCube(p + Vector3.back,  Vector3.one);
        }

        Gizmos.color = Color.white;
        foreach (Line l in turnBoundaries)
        {
            l.DrawWithGizmos(10);
        }
    }
}
