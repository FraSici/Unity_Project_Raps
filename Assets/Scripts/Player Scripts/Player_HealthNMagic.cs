using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HealthNMagic : Generic_Health
{

    [Header("Health Parameters")]
    public SignalSO playerHealthSignal;

    [Header("Mana Parameters")]
    [SerializeField] FloatValue currentMana;
    public SignalSO playerManaSignal;
    public float manaCost;
    public float manaRecovery = 5f;

    [Header("Others")]
    private bool canRecover = true;
    [SerializeField] public float coolDownTime;
    [SerializeField] public float startingCoolDownTime = 5f;
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
//        DeathCheck();
        if (currentMana.RuntimeValue < currentMana.initialValue)
        {
            ManaRecovery(manaRecovery);
        }        
    }

    
    private void DeathCheck() //if the player health reaches 0 it will run
    {
        if (maxHealth.RuntimeValue <= 0) {
            GetComponent<Player_Base>().isAlive = false; // this is checked in the update, when false disables player inputs
            myRigidBody.constraints = RigidbodyConstraints2D.FreezePosition; // if i don't lock its position, the last bounce with the enemy pushes the player towards inifinity
            myAnimator.SetBool("dead", true);//triggers the death animation
            StartCoroutine(GetComponent<Player_Base>().LoadNextScene());
        }
    }

    public void ActionFatigue(float manaCost, float healthCost)
    {
        if (currentMana.RuntimeValue > 0)
        {
            currentMana.RuntimeValue -= manaCost;
            playerManaSignal.Raise();
        }
         else if (currentMana.RuntimeValue <= 0)
        {
            Damage(healthCost);
        }
    }

    public void ManaRecovery(float recoveryPts)
    {
        if (coolDownTime <= 0)
        {
            currentMana.RuntimeValue += recoveryPts;
            playerManaSignal.Raise();
        }
        else
        {
            coolDownTime -= Time.fixedDeltaTime;
        }

        if (currentMana.RuntimeValue > currentMana.initialValue)
        {
            currentMana.RuntimeValue = currentMana.initialValue;
            playerManaSignal.Raise();
        }
    }

    public override void Damage(float amount2Damage)
    {
        base.Damage(amount2Damage);
        playerHealthSignal.Raise();
    }

}
