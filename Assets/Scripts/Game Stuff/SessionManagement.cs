using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SessionManagement : MonoBehaviour {


    [SerializeField] float LevelLoadDelay = 0f;
    [SerializeField] float LevelSlowMo = 0f;
    public Animator sceneTransitionAnimator;
    public AudioSource fadeInFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {

        sceneTransitionAnimator.SetTrigger("sceneTransition");
        fadeInFX.Play();
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
//        Time.timeScale = 1f;

        var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
        MusicPlayer.Destroy(gameObject);
    }

}

