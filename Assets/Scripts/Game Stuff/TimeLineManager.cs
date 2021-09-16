using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineManager : MonoBehaviour
{

    private bool fix = false;
    public Animator playerAnim;
    public RuntimeAnimatorController playerAnimRunTime;
    public PlayableDirector director;

    // Start is called before the first frame update
    void OnEnable()
    {
        playerAnimRunTime = playerAnim.runtimeAnimatorController;
        playerAnim.runtimeAnimatorController = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing)
        {
            fix = true;
            playerAnim.runtimeAnimatorController = playerAnimRunTime;
        }
    }
}
