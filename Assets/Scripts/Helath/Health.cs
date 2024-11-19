using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    public GameObject gameOverUI;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            print("Player Dead");
            PlayerDead();
            dead = true;






        }
        else
        {
            print("player hurt");
            anim.SetTrigger("hurt");
        }
    }

   
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    //Respawn
   
    private IEnumerator ShowGameOverUi()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);

    }
    private void PlayerDead()
    {
        anim.SetBool("grounded", true);
        anim.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false;

        //dzing animation

        GetComponent<ScreenFader>().StartFade();
        StartCoroutine(ShowGameOverUi());
        SoundManager.Instance.playerChannel.Stop();


    }
}