using UnityEngine;

public class Collect : MonoBehaviour
{
    
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private int value;
    private bool hasTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pim") && !hasTriggered)
        {
            hasTriggered = true;
            //collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}