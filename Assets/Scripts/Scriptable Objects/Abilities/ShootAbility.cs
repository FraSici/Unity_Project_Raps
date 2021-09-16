using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Shoot Ability", fileName  = "Shoot Ability")]
public class ShootAbility : GenericAbility
{

    [SerializeField] GameObject projectilePrefab;

    public override void Ability(Vector2 playerPosition, Vector2 direction, Animator playerAnimator = null, Rigidbody2D playerRb = null)
    {
        base.Ability(playerPosition, direction, playerAnimator, playerRb);
        float facingRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//NOTE: Atan2 outputs angle in radiants, starting from 0 i.e. positive x. Reorient eveything accordingly!!
        GameObject projectileInstance = Instantiate(projectilePrefab, playerPosition, Quaternion.Euler(0f, 0f, facingRotation));
        Generic_Shot temp = projectileInstance.GetComponent<Generic_Shot>();
        if (temp)
        {
            temp.SetUp(direction);
        }
    }

}
