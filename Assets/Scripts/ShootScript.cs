using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;


public class ShootScript : MonoBehaviour
{

    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] List<GameObject> markedList = new List<GameObject>();
    [SerializeField] float shootForce = 100f;

    [Header("Input System")]
    [SerializeField] public Vector2 direction;
    [SerializeField] public GameControls controls;


    private void Awake()
    {
        controls = new GameControls();

    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Player.Aim.performed += ctx => GetAimInput(ctx);
        controls.Player.Aim.canceled += ctx => direction = Vector2.zero;
    }
    private void OnDisable()
    {
        controls.Player.Aim.performed -= ctx => GetAimInput(ctx);
        controls.Disable();
    }
    private void Start()
    {
        direction = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
        Aiming();
 
//        ShootMarked();
    }
    private void GetAimInput(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    private void Aiming()
    {

        //Vector2 aim = new Vector2(Input.GetAxis("Aim Horizontal"), - Input.GetAxis("Aim Vertical"));
        Vector2 aim = new Vector2(direction.x, direction.y);
        if (aim.magnitude > 0)
        {
            aim.Normalize();
            aim *= 0.7f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true);
        }
        else
        {
            crossHair.SetActive(false);
        }
    }
    public void Shooting()
    {
        if (GetComponent<Player_Base>().objectInRange == false)
        {
            Vector2 instancePosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 shootingDirection = new Vector2(direction.x, direction.y);
            shootingDirection.Normalize();
            //Quaternion.Euler() takes a V2 or V3 as input and derives the angle!
            GameObject shotInstance = Instantiate(shotPrefab, instancePosition, Quaternion.identity);
            shotInstance.transform.rotation = Quaternion.Euler(GetAngle(shootingDirection));
            shotInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
            shotInstance.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(shotInstance, 2.0f);
        }
        else
        {
            Debug.Log("Can't shoot, look at obj");
        }
    }

    Vector3 GetAngle(Vector2 dir)
    {
        float temp = Mathf.Atan2(dir.x, dir.y);
        return new Vector3(0, 0, temp);
    }

    public void AddToMarked(GameObject marked)
    {
        if (markedList.Count < 1)
        {
            Debug.Log("Enemy Marked!");
            markedList.Add(marked);
            marked.GetComponent<Base_Enemy>().Marked = true;
            marked.GetComponent<SpriteRenderer>().color = Color.green;
        }else
        {
            Debug.Log("Reached maximum number of simultaneous markable enemies = " + markedList.Count);
        }

    }

    public void ShootMarked()
    {
        Debug.Log("Unleashing Hell");
        foreach (GameObject foe in markedList)
        {
            Vector2 instancePosition = new Vector2(transform.position.x, transform.position.y);
            GameObject shotInstance = Instantiate(shotPrefab, instancePosition, Quaternion.identity);
            Vector2 shootingDirection = new Vector2(foe.transform.position.x - transform.position.x, foe.transform.position.y - transform.position.y);
            shootingDirection.Normalize();
            shotInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection * 100);
            shotInstance.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(shotInstance, 2.0f);
        }
    }

    /*    private void Shooting()
    {
        if (Input.GetButtonDown("Fire3_A") && GetComponent<Player_Base>().objectInRange == false) 
        {
            Vector2 instancePosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 shootingDirection = new Vector2(Input.GetAxis("Aim Horizontal"), -Input.GetAxis("Aim Vertical"));
            shootingDirection.Normalize();
            //Quaternion.Euler() takes a V2 or V3 as input and derives the angle!
            GameObject shotInstance = Instantiate(shotPrefab, instancePosition, Quaternion.identity);
            shotInstance.transform.rotation = Quaternion.Euler(GetAngle(shootingDirection));
            shotInstance.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootForce);
            shotInstance.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(shotInstance, 2.0f);
        }
        else if (Input.GetButtonDown("Fire3_A") && GetComponent<Player_Base>().objectInRange == false) 
        {
            Debug.Log("Can't shoot, look at obj");
        }
    }
*/
}
