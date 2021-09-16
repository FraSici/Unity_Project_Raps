using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using Cinemachine;


public class Player_Melee : MonoBehaviour
{

    Animator myAnimator;

    private int comboCounter = 0;
    private float comboTimer = 0;
    private bool isIntervalOver = false;
    private bool hasChained = false;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public IEnumerator FirstAttack()
    {

        comboCounter = 1;
        myAnimator.SetInteger("comboSequence", comboCounter);
        GetComponent<Player_Base>().currentState = PlayerState.attack;
        yield return null;

        StartCoroutine(IntervalCounter());
        if (hasChained)
        {
            yield break;
        }
        yield return new WaitUntil(() => isIntervalOver);
        comboCounter = 0;
        myAnimator.SetInteger("comboSequence", comboCounter);
        if (GetComponent<Player_Base>().currentState != PlayerState.interact)
        {
            GetComponent<Player_Base>().currentState = PlayerState.walk;
        }
        isIntervalOver = false;
        hasChained = false;
    }

    public IEnumerator SecondAttack()
    {
        comboCounter = 2;
        myAnimator.SetInteger("comboSequence", comboCounter);
        GetComponent<Player_Base>().currentState = PlayerState.attack;
        yield return null;

        yield return new WaitForSeconds(AttackTemplate.SetDuration(0.7f));
        comboCounter = 0;
        myAnimator.SetInteger("comboSequence", comboCounter);

        if (GetComponent<Player_Base>().currentState != PlayerState.interact)
        {
            GetComponent<Player_Base>().currentState = PlayerState.walk;
        }

    }

    private IEnumerator IntervalCounter()
    {
        comboTimer = AttackTemplate.SetComboTimer(0.4f);
        //if combo not triggered:
        while (comboTimer >= 0)
        {
            comboTimer -= Time.deltaTime;
/*           WARNING ==> This commented out part is related to the combo section, currently commented out because relying on the old input 
 *           system, will be updated after main framework is re-established
 *           
 *           if (Input.GetButtonDown("Fire1_B"))
            {
                hasChained = true;
                StartCoroutine(SecondAttack());
                yield break;
            }*/
            if (comboTimer < 0)
            {
                isIntervalOver = true;
                yield break;
            }
            yield return null;
        }

    }

 /*   private IEnumerator IntervalCounter()
    {
        comboTimer = AttackTemplate.SetComboTimer(0.4f);
        Debug.Log("waiting after attack");
        //if combo not triggered:
        while (comboTimer >= 0)
        {
            comboTimer -= Time.deltaTime;
            if (Input.GetButtonDown("Fire1_B"))
            {
                hasChained = true;
                StartCoroutine(SecondAttack());
                yield break;
            }
            if (comboTimer < 0)
            {
                isIntervalOver = true;
                yield break;
            }
            Debug.Log("end waiting");
            yield return null;
        }

    }
 */
    public IEnumerator AoEAttack()
    {
        comboCounter = 3;
        myAnimator.SetInteger("comboSequence", comboCounter);
        GetComponent<Player_Base>().currentState = PlayerState.attack;
        yield return null;
        yield return new WaitForSeconds(AttackTemplate.SetDuration(1.0f));
        GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        yield return new WaitForSeconds(AttackTemplate.SetDuration(1.5f));
        comboCounter = 0;
        myAnimator.SetInteger("comboSequence", comboCounter);

        if (GetComponent<Player_Base>().currentState != PlayerState.interact)
        {
            GetComponent<Player_Base>().currentState = PlayerState.walk;
        }

    }
}
