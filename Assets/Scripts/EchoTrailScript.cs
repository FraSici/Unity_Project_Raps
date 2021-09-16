using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoTrailScript : MonoBehaviour
{
    private float timeBtwSpawns;
    private float startSpawningTime;

    public GameObject[] echoes;
    public GameObject player;



    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
           
            int rand = Random.Range(0, echoes.Length);
            GameObject instance = (GameObject)Instantiate(echoes[rand], transform.position, Quaternion.identity);
            Destroy(instance, 0.8f);
            timeBtwSpawns = startSpawningTime;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }    
    }
}
