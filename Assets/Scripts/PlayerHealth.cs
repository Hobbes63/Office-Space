using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    TextMeshProUGUI health;
    public float currentHealth = 100.0f;
    public float maximumHealth = 100.0f;

    private float lastHitTime = 0f;
    private float regenDelay = 10f;
    private float regenAmount = 2f;
    private float regenRate = 5f; // Regenerate every 1 second
    private float nextRegenTime = 0f;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("healthText").GetComponent<TextMeshProUGUI>();
        UpdateHealthDisplay();
        lastHitTime = Time.time;
    }

    void Update()
    {
        // Check if enough time has passed since last hit
        if (currentHealth < maximumHealth && Time.time > lastHitTime + regenDelay)
        {
            // Check if it's time to regenerate
            if (Time.time >= nextRegenTime)
            {
                Regenerate();
                nextRegenTime = Time.time + regenRate;
            }
        }
    }

    void Regenerate()
    {
        currentHealth += regenAmount;

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }

        UpdateHealthDisplay();
        Debug.Log("Player regenerated 2 health. Current health: " + currentHealth);
    }

    void UpdateHealthDisplay()
    {
        health.text = "Health " + currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        lastHitTime = Time.time; // Reset timer when taking damage

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthDisplay();
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // Add death logic here (reload scene, game over screen, etc.)
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only take damage from projectiles/enemies, not the ground!
        if (other.CompareTag("Bullet") || other.CompareTag("Enemy"))
        {
            currentHealth -= 20;
            lastHitTime = Time.time;
            UpdateHealthDisplay();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset timer if player collides with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lastHitTime = Time.time;
        }
    }
}