using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{

    [Header("Observer Parameters")]
    public GameObject[] enemies;
    public GameObject[] breakables;

    [Header("Generalities")]
    public GameObject virtualCamera;
    public bool needText;
    public string placeName;
    public GameObject text;
    public TextMeshProUGUI placeText1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CheckEnemiesNBreakables(true);
            virtualCamera.SetActive(true);
            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }

        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CheckEnemiesNBreakables(false);
            virtualCamera.SetActive(false);

        }

    }

    public IEnumerator PlaceNameCo()
    {
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        placeText1.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }

    public void CheckEnemiesNBreakables(bool roomActive)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            ChangeActivation(enemies[i], roomActive);
        }
        for (int i = 0; i < breakables.Length; i++)
        {
            ChangeActivation(breakables[i], roomActive);
        }
    }
    
    public void ChangeActivation(GameObject go, bool activation) {
        go.SetActive(activation);
    }

}
