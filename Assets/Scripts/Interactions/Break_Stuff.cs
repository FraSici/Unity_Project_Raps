using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Break_Stuff : MonoBehaviour
{
    private Animator myAnimator;
    private Collider2D myCollider;
    [SerializeField] AudioClip breakSound;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Breaking() {
        myAnimator.SetBool("isBreaking", true);
        GetComponent<AudioSource>().PlayOneShot(breakSound);
        DestroyObject(gameObject, 5f);
    }
}
