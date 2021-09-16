using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/MultiShoot Ability", fileName = "MultiShoot Ability")]
public class MultiShootAbility : GenericAbility
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int nProjectiles;
    [SerializeField] float projectilesSpread;

    public override void Ability(Vector2 playerPosition, Vector2 direction, Animator playerAnimator = null, Rigidbody2D playerRb = null)
    {
        base.Ability(playerPosition, direction, playerAnimator, playerRb);
        float facingRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//NOTE: Atan2 outputs angle in radiants, starting from 0 i.e. positive x. Reorient eveything accordingly!!
        float startRotation = facingRotation + projectilesSpread / 2f;
        float angleIncrease = projectilesSpread / ((float)nProjectiles - 1);

        for (int i = 0; i < nProjectiles; i++)
        {
            float tempRotation = startRotation - angleIncrease * i;
            GameObject projectileInstance = Instantiate(projectilePrefab, playerPosition, Quaternion.Euler(0f, 0f, tempRotation));
            Generic_Shot temp = projectileInstance.GetComponent<Generic_Shot>();
            if (temp)
            {
                temp.SetUp(new Vector2(Mathf.Cos(tempRotation * Mathf.Deg2Rad) , Mathf.Sin(tempRotation * Mathf.Deg2Rad)));
            }
        }

    }
}
