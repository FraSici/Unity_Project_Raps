using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string scene2Load;
    public Vector2 playerPosition;
    public VectorValue positionStorage;
    public Animator sceneTransitionAnimator;
    public AudioSource fadeInFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            StartCoroutine(LoadScene());
        }
    }
    
    private IEnumerator LoadScene()
    {
        sceneTransitionAnimator.SetTrigger("sceneTransition");
        fadeInFX.Play();
        yield return new WaitForSecondsRealtime(0.7f);
        positionStorage.initialValue = playerPosition;
        SceneManager.LoadScene(scene2Load);
    }

}
