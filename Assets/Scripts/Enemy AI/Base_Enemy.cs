using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    idle,
    walk,
    attack,
    aim,
    interact,
    dash,
    stagger,
    die
}

public class Base_Enemy : MonoBehaviour
{
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAtk;
    public EnemyState currentState;
    public float speed;
    public Transform target;
    public Transform homePosition;

    public bool isAlive;
    public Animator anim;
    public Rigidbody2D rb;
    public CapsuleCollider2D coll;
    public AudioSource enemyAudio;
    public float push = 3;
    public float knockBackTime = 0.2f;
    [SerializeField] AudioClip[] dmgSounds;

    public GameObject deathFX;
    public SignalSO roomSignal;
    public LootTable enemyLoot;

    public float chaseRadius;
    public float attackRadius;

    public bool replaceInHome = true;
    private bool isMarked;
    public bool Marked
    {
        get { return isMarked; }
        set { isMarked = value; }
    }

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentState = EnemyState.idle;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        enemyAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            DeathFX();
            MakeLoot();
            if (roomSignal != null)
            {
                roomSignal.Raise();
            }
            this.gameObject.SetActive(false);
        }
    }

    private void MakeLoot()
    {
        if (enemyLoot != null)
        {
            GameObject current = enemyLoot.LootPowerUp();
            if (current != null)
            {
                Instantiate(current, transform.position, Quaternion.identity);
            }
        }
    }

    private void DeathFX()
    {
        if (deathFX != null)
        {
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(fx, 1f);
        }
    }

    public void ReduceHealt(int dmg)
    {
        health -= dmg;
    }

    public void KnockBack()
    {
        currentState = EnemyState.stagger;
        Vector2 distance = rb.transform.position - target.position;
        distance = distance.normalized;
        rb.AddForce(distance * push, ForceMode2D.Impulse);
        StartCoroutine(KnockCo(rb));
    }

    private IEnumerator KnockCo(Rigidbody2D enemyRb)
    {
        //enemyAudio.PlayOneShot(dmgSounds[1]);
        yield return new WaitForSecondsRealtime(knockBackTime);
        enemyRb.velocity = Vector2.zero;
        currentState = EnemyState.idle;
    }

    public IEnumerator Death()
    {

        anim.SetTrigger("Death");
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        //AudioSource.PlayClipAtPoint(dmgSounds[0], transform.position);
        Destroy(gameObject, 3f);


        yield return null;
    }

    public virtual void CheckDistance()
    {
        if (Vector3.SqrMagnitude(target.position - transform.position) <= chaseRadius && Vector3.SqrMagnitude(target.position - transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                UpdateWalkingAnimation(temp);
            }
        }
    }

    public void UpdateWalkingAnimation(Vector3 directionInput)
    {
        Vector3 v = new Vector3(directionInput.x, directionInput.y, 0);
        Vector3 d = (v - transform.position);
        d.Normalize();
        anim.SetFloat("MoveX", d.x);
        anim.SetFloat("MoveY", d.y);
        anim.SetBool("isMoving", true);
    }

    public void UpdateWalkingAnimation(Vector2 directionInput)
    {
        Vector3 v = new Vector3(directionInput.x, directionInput.y, 0);
        Vector3 d = (v - transform.position);
        d.Normalize();
        anim.SetFloat("MoveX", d.x);
        anim.SetFloat("MoveY", d.y);
        anim.SetBool("isMoving", true);
    }

    public void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    private void OnEnable()
    {
        if (replaceInHome)
        {
            transform.position = homePosition.position;
        }
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }
}