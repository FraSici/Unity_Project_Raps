using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{
    public Door[] doors;

    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
        }

        OpenAllDoors();
    }

    public void CloseAllDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
    }

    public void OpenAllDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].OpenDoor();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CheckEnemiesNBreakables(true);
            CloseAllDoors();
            virtualCamera.SetActive(true);
            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }

        }
        
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CheckEnemiesNBreakables(false);
            virtualCamera.SetActive(false);

        }

    }

}
