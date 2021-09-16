using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Up : PowerUp 
{

    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float healthIncrease;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += healthIncrease;
            if (playerHealth.initialValue > heartContainers.RuntimeValue * 20f)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 20f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
