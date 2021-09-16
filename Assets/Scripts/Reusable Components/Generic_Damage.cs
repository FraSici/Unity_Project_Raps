using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Generic_Damage : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Generic_Health temp = other.GetComponent<Generic_Health>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }

}
