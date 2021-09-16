using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTemplate
{

    public int damage;
    public float duration;
    public float intervalForCombo;

    public static int SetDamage(int dmg)
    {
        return dmg;
    }

    public static float SetDuration(float duration)
    {
        return duration;
    }

    public static float SetComboTimer(float timeForCombo)
    {
        return timeForCombo;
    }

    public static void specialFXATK()
    {
        //there will be multiple methods like this, they implement special features in the attack e.g. poisoning, staggering etc.
    }

}
