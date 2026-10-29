using UnityEngine;

public class TowerWatercooler : Tower, IInteractable
{
    public float healAmount = 20f;
    public float cooldown;
    public float maxCooldown;

    public PlayerManager player;

    public void Start()
    {
        player = PlayerManager.FindAnyObjectByType<PlayerManager>();
        cooldown = 0;
    }

    public override void TowerBehavior()
    {
        if (cooldown < maxCooldown)
        {
            cooldown += Time.deltaTime;
        }
    }

    public void Interact()
    {
        if (cooldown >= maxCooldown)
        {
            if (player != null)
            {
                player.currentHealth += healAmount;
                if (player.currentHealth > player.maximumHealth)
                {
                    player.currentHealth = player.maximumHealth;
                }
            }

            player.UpdateHealthDisplay();

            cooldown = 0;
        }
    }
}
