using UnityEngine;

public class FollowingTrap : EnemyDamage
{
    [Header("FollowingTrap")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private float checkTimer;
    private bool attacking;
    [Header("SFX")]
    [SerializeField] private AudioClip impactSound;

    

    private void OnEnable() {
        Stop();
    }


    
    void Update()
    {
        if(attacking)
         {   
            transform.Translate(destination * Time.deltaTime * speed);
         }
         else
         {
            checkTimer += Time.deltaTime;
            if(checkTimer>checkDelay)
            {
              CheckForPlayer();   
              for(int i = 0; i < directions.Length; i++) 
              {
                Debug.DrawRay(transform.position, directions[i], Color.red);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i],range, playerLayer);
                if(hit.collider != null && !attacking) 
                {
                    attacking = true;
                    destination = directions[i];
                    checkTimer = 0;
                }
              }
            }

         }
    }

    private void CheckForPlayer () 
    {
        CalculateDirections();
    }

    private void CalculateDirections () 
    {
        directions[0] = transform.right*range;
        directions[1] = -transform.right*range;
        directions[2] = transform.up*range;
        directions[3] = -transform.up*range;
    }
    private void Stop () 
    {
        destination = transform.position;
        attacking = false;
    }
    
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.zombieChannel.clip = SoundManager.Instance.zombieWalking;
        base.OnTriggerEnter2D(collision);
        Stop();
    } 





}
