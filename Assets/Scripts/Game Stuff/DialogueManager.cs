using System.Collections; // needed for the Queue
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;


    [SerializeField] float LevelLoadDelay = 5f;
    [SerializeField] float LevelSlowMo = 1f;


    private Queue<string> sentences; //FIFO collection (first in first out), works as a list but it is more redstrictive

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.speaker;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("isOpen", false);
        StartCoroutine(LoadNextScene());
    }
    
    IEnumerator LoadNextScene() {
        
        Time.timeScale = LevelSlowMo;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
