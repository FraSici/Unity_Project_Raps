using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    public SignalSO healthSignal;

    public void UseItem(int amount2Increase)
    {
        playerHealth.RuntimeValue += amount2Increase;
        healthSignal.Raise();
    }

}
