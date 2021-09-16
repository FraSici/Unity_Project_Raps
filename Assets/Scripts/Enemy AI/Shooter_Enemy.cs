using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Enemy : Base_Enemy
{

    public GameObject projectile;
    public float fireRate;
    public float cooldownShot;
    public bool canFire = true;

    private void Update()
    {
        CheckDistance();
        cooldownShot -= Time.deltaTime;
        if (cooldownShot <= 0)
        {
            canFire = true;
            cooldownShot = fireRate;
        }
    }

    public override void CheckDistance()
    {
        if (Vector3.SqrMagnitude(target.position - transform.position) <= attackRadius)
        {
            if (canFire)
            {
                Vector3 temp = target.position - transform.position;
                GameObject tempProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                tempProjectile.GetComponent<Enemy_Shoot>().Shoot(temp);
                canFire = false;
            }
        }
        else
        {

        }
    }

}
