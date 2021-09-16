using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.InputSystem;

/*enum PlayerState is a list of states that can be taken by the player character. They will be used to implement a finite state machine-like
behavior with the actions it can take
The states will stay in the base player template
 */
public enum PlayerState {
    walk,
    attack,
    aim,
    interact,
    inspect,
	dash,
    stagger,
    useAbility
}

public class Player_Base : MonoBehaviour {


    [Header("Ability parameters")]
    [SerializeField] GenericAbility currentAbility;
    [SerializeField] Vector2 tempMovement = Vector2.down;
    [SerializeField] Vector2 facingDirection;

    [Header("Base parameters")]
    public Inventory playerInventory;
    public SpriteRenderer receiveItemSprite;
    Rigidbody2D myRigidBody; //These are to call the components of the Player GameObject
    public static Transform playerPos;
    public PlayerState currentState;
    Animator myAnimator;
    public VectorValue startingPosition;
    public bool objectInRange = false;

    private bool alive = true;
    public bool isAlive
    {
        get { return alive; }
        set { alive = value; }
    }

    [Header("Sorting layer parameters")]
    public CapsuleCollider2D myFeet;
    public static float playerVertPos; // Need this to sort other objects layers in another script.

    [Header("Sound parameters")]
    [SerializeField] AudioClip[] sounds;
    [SerializeField] private new AudioSource audio;

    [Header("IFrame parameters")]
    public Color flashColor;
    public float flashDuration;
    public int numFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;

    public float push = 3f;
    public float knockBackTime = 0.2f;

    [Header("Input System")]
    [SerializeField] public GameControls controls;

    private void Awake()
    {
        controls = new GameControls();
        
    }
    private void OnEnable()
    {
        controls.Enable();
        
        controls.Player.Melee_A.performed += ctx =>
        {
            if(currentState != PlayerState.attack && currentState != PlayerState.stagger)
            {
                StartCoroutine(GetComponent<Player_Melee>().FirstAttack());
                GetComponentInChildren<Player_HealthNMagic>().ActionFatigue(5f, 10f);
                GetComponentInChildren<Player_HealthNMagic>().coolDownTime = GetComponentInChildren<Player_HealthNMagic>().startingCoolDownTime;
            }
            
        };
        
        controls.Player.Melee_X.performed += ctx =>
        {
            if(currentState != PlayerState.attack && currentState != PlayerState.stagger)
            {
                StartCoroutine(GetComponent<Player_Melee>().SecondAttack());
                GetComponentInChildren<Player_HealthNMagic>().ActionFatigue(5f, 10f);
                GetComponentInChildren<Player_HealthNMagic>().coolDownTime = GetComponentInChildren<Player_HealthNMagic>().startingCoolDownTime;
            }
            
        };
        
        controls.Player.Dash_B.performed += ctx =>
        {
            if(currentState != PlayerState.dash && currentState != PlayerState.stagger)
            {
                StartCoroutine(GetComponent<Player_Movement>().Dashing());
            }
        };
        
        controls.Player.Fire_RT.performed += ctx =>
        {
            GetComponent<ShootScript>().Shooting();
            GetComponentInChildren<Player_HealthNMagic>().ActionFatigue(5f, 10f);
            GetComponentInChildren<Player_HealthNMagic>().coolDownTime = GetComponentInChildren<Player_HealthNMagic>().startingCoolDownTime;
        };

    }

    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {        
        currentState = PlayerState.walk;//Initial default state of the player
        myRigidBody = GetComponent<Rigidbody2D>(); /*the getcomp looks for the related component in the <> and uses it in the code*/
        myFeet = GetComponent<CapsuleCollider2D>();

        transform.position = startingPosition.initialValue;
        myAnimator = GetComponent<Animator>();
 
//      TODO  the trail renderer should go in some FEATURES script
        GetComponent<TrailRenderer>().enabled = false ;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerVertPos = myFeet.bounds.center.y;//Stays together with the sorting logic
        if (currentState == PlayerState.interact)
        {
            return;
        }
        
        if (!isAlive)
        {
            return;
        }
        /*
        //this logic stays here and calls the methods from other classes
        else {
            if (currentState == PlayerState.walk)//It will consider walking only when in that state, this means that if it is attacking for instance,
			                                     //it needs to change its state. Good for compartimentalization of the actions (otherwise I could have changed the direction of the attacks)
            {
                if (GetComponent<Player_Movement>().direction != Vector2.zero)//This if statement is such that if there is no new input to update the movement with, the last (idle) animation 
				                                                              //will remain, so if you go right and stop, the player keeps facing right
                {
                    GetComponent<Player_Movement>().Move();
                    GetComponent<Player_Movement>().AnimatorOnMove();
                }
                else {
                    myAnimator.SetBool("isMoving", false);
                }
            }
            
            //Attack inputs
            if (Input.GetButtonDown("Fire1_B") && currentState != PlayerState.attack && currentState != PlayerState.stagger)//second clause because i do not want to indefinitely attack every frame
            {
                Debug.Log("Entered wrong 1st melee");
                StartCoroutine(GetComponent<Player_Melee>().FirstAttack());
                GetComponentInChildren<Player_HealthNMagic>().ActionFatigue(25f, 30f);
                GetComponentInChildren<Player_HealthNMagic>().coolDownTime = GetComponentInChildren<Player_HealthNMagic>().startingCoolDownTime;
            }
            else if (Input.GetButtonDown("Fire4_Y") && currentState != PlayerState.attack && currentState != PlayerState.stagger)//second clause because i do not want to indefinitely attack every frame
            {
                Debug.Log("Entered wrong 2nd melee");
                StartCoroutine(GetComponent<Player_Melee>().SecondAttack());
            }
            else if (Input.GetButtonDown("Ability_R3") && currentState != PlayerState.attack && currentState != PlayerState.stagger)//second clause because i do not want to indefinitely attack every frame
            {
                Debug.Log("Entered wrong AOE");
                StartCoroutine(GetComponent<Player_Melee>().AoEAttack());
                Debug.Log("AoE");
                audio.PlayOneShot(sounds[2]);
                //TRIAL Input.GetKeyDown(KeyCode.A) -- Input.GetButtonDown("Ability_R3") -- Input.GetAxis("Dash")
            }

            if (Input.GetButtonDown("Dash_R1") && currentState != PlayerState.dash && currentState != PlayerState.stagger)
            {
                Debug.Log("Entered wrong Dash");
                //          AbilityCo      audio.PlayOneShot(sounds[1]);
                StartCoroutine(GetComponent<Player_Movement>().Dashing());
            }
            if (Input.GetButtonDown("Ability_L1") && currentState != PlayerState.dash && currentState != PlayerState.stagger)
            {
                StartCoroutine(AbilityCo(0.2f));
            }

        
            //     DeathCheck();//check if player is still alive

        }*/
    }

    //Loading logic can stay here
    [SerializeField] float LevelLoadDelay = 3f;
    [SerializeField] float LevelSlowMo = 1f;
    public IEnumerator LoadNextScene()
    {
        Debug.Log("loading next scene");
        Time.timeScale = LevelSlowMo;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
   
    public void KnockBack(GameObject hitter)
    {
        currentState = PlayerState.stagger;
        Vector2 distance = myRigidBody.transform.position - hitter.transform.position;
        distance = distance.normalized;
        myRigidBody.AddForce(distance * push, ForceMode2D.Impulse);
        StartCoroutine(KnockCo(myRigidBody));
    }

    private IEnumerator KnockCo(Rigidbody2D rb)
    {
        StartCoroutine(FlashCo());
        //enemyAudio.PlayOneShot(dmgSounds[1]);
        yield return new WaitForSecondsRealtime(knockBackTime);
        rb.velocity = Vector2.zero;
        currentState = PlayerState.walk;
    }

    public void GetItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                myAnimator.SetBool("gotItem", true);
                currentState = PlayerState.interact;
                receiveItemSprite.sprite = playerInventory.currentItem.itemSprite;

            }
            else
            {
                myAnimator.SetBool("gotItem", false);
                currentState = PlayerState.walk;
                receiveItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    private IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while (temp < numFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = Color.white;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        mySprite.color = Color.white;
        triggerCollider.enabled = true;
    }

    public IEnumerator AbilityCo(float abilityDuration)
    {
        GetComponent<Player_Base>().currentState = PlayerState.useAbility;
        currentAbility.Ability(transform.position, GetComponent<Player_Movement>().moveInput.normalized, myAnimator, myRigidBody);
        yield return new WaitForSeconds(abilityDuration);
        GetComponent<Player_Base>().currentState = PlayerState.walk;
       
    }
}


