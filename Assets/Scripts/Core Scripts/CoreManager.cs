
using UnityEngine;
using TMPro;

public class CoreManager : MonoBehaviour, IInteractable
{
    [Header("Core Health")]
    public float coreCurrentHP;
    public float coreMaxHP = 100f;
    public float enemyDamage = 20f;

    public TextMeshProUGUI coreHealthText;
    public GameObject effectRadius;

    [Header("Interaction")]
    private bool playerInsideCore = false;

    private void Start()
    {
        coreCurrentHP = coreMaxHP;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (coreHealthText != null)
        {
            coreHealthText.text =
                "Core Health: " + coreCurrentHP + "/" + coreMaxHP;
        }
    }

    public void TakeDamage(float damage)
    {
        if (coreCurrentHP <= 0)
            return;

        coreCurrentHP -= damage;

        coreCurrentHP = Mathf.Max(0, coreCurrentHP);

        UpdateHealthDisplay();

        if (coreCurrentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Core has been destroyed!");

        // Add game over logic here.
    }

    private void OnTriggerEnter(Collider other)
{
    Debug.Log("Entered: " + other.name + " Tag: " + other.tag);

    if (other.CompareTag("Player"))
    {
        playerInsideCore = true;
        Debug.Log("Player entered Core.");
    }

    if (other.CompareTag("Enemy"))
    {
        Debug.Log("Enemy hit Core.");
        TakeDamage(enemyDamage);
    }
}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideCore = false;
            Debug.Log("Player left Core.");
        }
    }

    public void Interact()
    {
        if (!playerInsideCore)
        {
            Debug.Log("You must be inside the Core to use it!");
            return;
        }

        if (TaskManager.Instance == null)
        {
            Debug.LogError("TaskManager not found!");
            return;
        }

        Debug.Log("Core Interacted!");

        TaskManager.Instance.StartTask();
    }
}
