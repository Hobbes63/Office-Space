using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    //Player Health Values
    TextMeshProUGUI health;
    public float currentHealth = 100.0f;
    public float maximumHealth = 100.0f;

    [SerializeField] public float currentSpeed; //adjust this to read from player controller

    //Player Regen Controls
    private float lastHitTime = 0f;
    private float regenDelay = 10f;
    private float regenAmount = 0.1f;
    private float regenRate = 5f; // Regenerate every 1 second
    private float nextRegenTime = 0f;

    public int playerLives;


    public List<KeyValuePair<string, int>> Stats;

    // AudioManager audioManager;

    // [Header("Footsteps")]
    // [SerializeField] public AudioClip[] footstepSounds;

    // private AudioSource sfxSource;

    // [Header("HP and Item pick-up")]
    // [SerializeField] public AudioClip playerHurt;
    // [SerializeField] public AudioClip playerHeal;
    // [SerializeField] public AudioClip playerLifeUp;
    // [SerializeField] public AudioClip playerDeath;

    // private AudioSource playerHurtSource;
    // private AudioSource playerHealSource;
    // private AudioSource playerLifeUpSource;
    // private AudioSource playerDeathSource;

    public Inventory playerInventory;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("healthText").GetComponent<TextMeshProUGUI>();
        UpdateHealthDisplay();
        lastHitTime = Time.time;



        Stats = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Speed", Mathf.RoundToInt(currentSpeed)),
            new KeyValuePair<string, int>("Health", Mathf.RoundToInt(currentHealth)),
            //new KeyValuePair<string, int>("Shield", shield),
            new KeyValuePair<string, int>("Lives", playerLives)

        };
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
        Debug.Log("Player regenerated " + regenAmount + " health. Current health: " + currentHealth);
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
        if (other.CompareTag("Enemy"))
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