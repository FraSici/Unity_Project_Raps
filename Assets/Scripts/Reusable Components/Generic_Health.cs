using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic_Health : MonoBehaviour
{

    public FloatValue maxHealth;
    public float fullHealth;



    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Heal(float amount2Heal)
    {
        maxHealth.RuntimeValue += amount2Heal;
        if (maxHealth.RuntimeValue > fullHealth)
        {
            maxHealth.RuntimeValue = fullHealth;
        }
    }

    public virtual void FullHeal()
    {
        maxHealth.RuntimeValue = fullHealth;
    }

    public virtual void Damage(float amount2Damage)
    {
        maxHealth.RuntimeValue -= amount2Damage;
        if (maxHealth.RuntimeValue < 0 )
        {
            maxHealth.RuntimeValue = 0;
        }
    }

    public virtual void InstantDeath()
    {
        maxHealth.RuntimeValue = 0;
    }

}
