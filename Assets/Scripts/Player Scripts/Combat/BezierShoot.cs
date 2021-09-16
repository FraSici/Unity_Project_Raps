using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierShoot : MonoBehaviour
{
    //TODO add target dynamically
    [SerializeField] GameObject target;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] float speed = 5f;
    private float t = 0;//the parameter for the bezier curve
    /**
         I want to try and make 2 points, one third and two thirds distance from player to object.
        1) I find the 1/4 and 3/4 distance on the connecting line
        2) I get the normalized distance from the new points from the target
        3) I get the perpendicular vector with respect to each point and the target and multiply by the distance parameter
        3.1) obtaining vector coordinates: I have direction tempDir
            normDir.x = tempDir.y
            normDir.y = -tempDir.x
         */

    private void Update()
    {
 /*TO BE UPDATE LATER
  * if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 CP1 = CreateControlPoint(0.25f, 2f);
            Vector3 CP2 = CreateControlPoint(0.75f, 2f);
            StartCoroutine(CubicBezierShooting(CP1, CP2));
        }
*/
    }
    
    private Vector3 CreateControlPoint(float yHatPosition, float xHatPosition)
    {
        Vector3 CP0 = transform.position;
        Vector3 CP_final = target.transform.position;
        Vector3 CP = new Vector3(CP0.x + (CP_final.x - CP0.x) * yHatPosition, CP0.y + (CP_final.y - CP0.y) * yHatPosition, 0);

        Vector2 yHat = new Vector2((CP_final.x - CP.x), (CP_final.y - CP.y));
        yHat.Normalize();
        Vector2 xHat;
        xHat.x = yHat.y;
        xHat.y = -yHat.x;
        Vector3 displacement = new Vector3(-xHat.x * xHatPosition, -xHat.y * xHatPosition, 0);
        CP = CP + displacement;
        //Debug.Log("position of CP: " + CP);

        return CP;
    }

    private IEnumerator CubicBezierShooting(Vector3 CP1, Vector3 CP2)
    {
        var shotInstance = Instantiate(shotPrefab, transform.position, Quaternion.identity);//instantiate the bullet
        Vector3 CP0 = transform.position;
        Vector3 CP_final = target.transform.position;
        //the parameter for the bezier curve goes from 0 to 1, therefore it has been initialised to 0 and 
        //the loop for the trajectory will go on until t=1 i.e. the bullet reached the target or hit something along the road
        while (t < 1 && shotInstance != null)
        {
            float invT = 1f - t;
            //the bezier curve equation. 4 points define a cubic bezier curve
            var currentPosition = invT * invT * invT * CP0
                                + 3 * invT * invT * t * CP1
                                + 3 * invT * t * t * CP2
                                + t * t * t * CP_final;
            shotInstance.transform.position = currentPosition;
            t += Time.deltaTime / 1f;
            yield return null;
        }

        t = 0;
    }

}
