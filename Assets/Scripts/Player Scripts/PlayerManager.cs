
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    [Header("Interaction")]
    public Camera mainCamera;
    public float interactionDistance = 2f;
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    [Header("Player Health")]
    [SerializeField] private TextMeshProUGUI health;

    public float currentHealth = 100f;
    public float maximumHealth = 100f;

    [Header("Player Stats")]
    public int playerDamage;
    public float baseSpeed = 3f;
    public int playerLives;

    [Header("Inventory")]
    public Inventory playerInventory;

    [Header("Health Regeneration")]
    [SerializeField] private float regenDelay = 10f;
    [SerializeField] private float regenAmount = 0.1f;
    [SerializeField] private float regenRate = 5f;

    private float lastHitTime;
    private float nextRegenTime;

    public List<KeyValuePair<string, int>> Stats;

    private void Start()
    {
        if (health == null)
        {
            GameObject healthObject =
                GameObject.FindGameObjectWithTag("healthText");

            if (healthObject != null)
                health = healthObject.GetComponent<TextMeshProUGUI>();
        }

        currentHealth = Mathf.Clamp(
            currentHealth, 0, maximumHealth
        );

        UpdateHealthDisplay();

        lastHitTime = Time.time;

        Stats = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>(
                "Speed", Mathf.RoundToInt(baseSpeed)
            ),

            new KeyValuePair<string, int>(
                "Health", Mathf.RoundToInt(currentHealth)
            ),

            new KeyValuePair<string, int>(
                "Lives", playerLives
            )
        };
    }

    private void Awake()
{
    if (playerInventory == null)
    {
        playerInventory = GetComponent<Inventory>();
    }
}

    private void Update()
    {
        if (currentHealth < maximumHealth &&
            Time.time >= lastHitTime + regenDelay)
        {
            if (Time.time >= nextRegenTime)
            {
                Regenerate();
                nextRegenTime = Time.time + regenRate;
            }
        }
    }

    private void Regenerate()
    {
        currentHealth += regenAmount;

        currentHealth = Mathf.Min(
            currentHealth, maximumHealth
        );

        UpdateHealthDisplay();
    }

    public void UpdateHealthDisplay()
    {
        if (health == null)
            return;

        health.text = "Health " +
                      currentHealth.ToString("F0") +
                      "/" +
                      maximumHealth.ToString("F0");
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;

        currentHealth = Mathf.Max(0, currentHealth);

        lastHitTime = Time.time;

        UpdateHealthDisplay();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(
            currentHealth + amount,
            maximumHealth
        );

        UpdateHealthDisplay();
    }

    private void Die()
    {
        Debug.Log("Player has died!");

        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(20f);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20f);
        }
    }
}
