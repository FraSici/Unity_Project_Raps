using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Up : PowerUp
{

    public Inventory playerInventory;
    public float manaValue;
    public FloatValue playerMana;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMana.RuntimeValue += manaValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
