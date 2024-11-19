using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text collectibelDisplay;
    public static CollectibleManager instance;
    private int collectible;

    private void Awake()
    
    {
        if(!instance) 
        {
            instance = this;   
        }   
    }

    private void OnGUI()
    {
        collectibelDisplay.text = collectible.ToString();   
    }
    public void ChangeCollectibles (int amount) 
    {
        collectible += amount;   
    }
}
