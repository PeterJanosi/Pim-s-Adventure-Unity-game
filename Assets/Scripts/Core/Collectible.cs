using UnityEngine;

public class Collectible : MonoBehaviour
{
  [SerializeField] private int value;
  private bool hasTriggered;
  private CollectibleManager collectibleManager;

  private void Start() 
  {
    collectibleManager = CollectibleManager.instance;
  }
  
  private void OnTriggerEnter2D(Collider2D collision) 
  {
    if (collision.CompareTag("Pim")&& !hasTriggered)
    {
        hasTriggered = true;
        collectibleManager.ChangeCollectibles(value);
        gameObject.SetActive(false);
        
    }


  }
    
  
}
