using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
   [SerializeField] private float attakCooldown;
   [SerializeField] private Transform firePoint;
   [SerializeField] private GameObject[] shots;
   private float cooldownTimer;

   private void Attack()
   {
     cooldownTimer = 0;

     shots[FindShots()].transform.position =firePoint.position;
     shots[FindShots()].GetComponent<EnemyProjectile>().ActivcateProjectile();

   }
   private int FindShots()
   {
    for (int i = 0; i < shots.Length; i++)
    {
        if (!shots[i].activeInHierarchy)
        {
            return i;
        }
    }
    return 0;
   }

   private void Update()
   {
      cooldownTimer += Time.deltaTime;
      if (cooldownTimer>=attakCooldown)
      {
        Attack();
      }      
   }
}
