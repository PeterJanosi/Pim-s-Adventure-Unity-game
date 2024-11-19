using UnityEngine;
using System.Collections; 


public class Checkpoint : MonoBehaviour
{
    public static GameController gameController;
    public Transform respawnPoint;
    Collider2D coll;


    private void Awake() {
        gameController = GameObject.FindGameObjectWithTag("Pim").GetComponent<GameController>();
        coll= GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pim"))
        {
           gameController.UpdateCheckpoint(respawnPoint.position);
           coll.enabled = false; 
        }
    }


}
