using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvicible = false;
    public SpriteRenderer graphics;
    public float invicibilityFlashDelay = 0.15f;
    public float invicibilityTimeAfterHit = 3f;


    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la sscene");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(120);
        }
    }

    public void HealPlayer(int amount)
    {
        if (currentHealth+amount> maxHealth)
            {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible) 
        { 
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth > 0) { 

                isInvicible = true;
                StartCoroutine(InvicibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }
            else
            {
                
                Die();
                return;
            }
        }
    }

    public void Die()
    {
        Debug.LogError("Die motha fuka");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.animator.ResetTrigger("Die");
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
