using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This loot class is a CUSTOM class, by default Unity won't show it in the editor 
 because it is not serialized. In order to serialize it and show it in the editor you
 must add [System.Serializable]*/
 [System.Serializable]
public class Loot
{
    public GameObject thisLoot;
    public int lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public GameObject LootPowerUp()
    {
        int cumulativeProb = 0;
        int currentProb = Random.RandomRange(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cumulativeProb += loots[i].lootChance;
            if (currentProb <= cumulativeProb)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }

}
