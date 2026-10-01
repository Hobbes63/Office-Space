using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class CoreManager : MonoBehaviour, IInteractable 
{
    public float coreCurrentHP;
    public float coreMaxHP;

    public Inventory playerInventory; //objects will be placed on the core, and 
    public GameObject effectRadius;

    public TextMeshProUGUI coreHealthText;

    public float enemyDamage = 20f;

    public enum Abilities { NoBoost, RegenBoost, SpeedBoost, FireRateBoost };

    public Abilities coreAttributes = Abilities.NoBoost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Start at full health
        coreCurrentHP = coreMaxHP;
        UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthDisplay()
    {

        if (coreHealthText != null)
        {

            coreHealthText.text = "Core Health: " + coreCurrentHP;
        }
    }

    public void TakeDamage(float damage)
    {

        coreCurrentHP -= damage;

        if (coreCurrentHP <= 0)
        {
            coreCurrentHP = 0;
            Die();
        }

        UpdateHealthDisplay();
    }

    void Die()
    {

        Debug.Log("Core has been destroyed!");
        // Add core destruction logic here (game over screen, reload scene, etc.)
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            TakeDamage(enemyDamage);      
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            TakeDamage(enemyDamage);  
        }
    }

    public void Interact()
    {
        
    }

    public void BoostPlayerRegen()
    {
        
    }

    public void AutoFire()
    {
        
    }
}
