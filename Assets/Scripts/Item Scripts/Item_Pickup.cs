using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public string itemName;
    public ItemType itemType;
    public int potency;
    public Sprite itemSprite;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Item item = new Item();

        item.name = itemName;
        item.type = itemType;
        item.potency = potency;
        item.itemCount = 1;
        item.itemSprite = itemSprite;

        PlayerManager player =
            other.GetComponent<PlayerManager>();

        player.playerInventory.AddToInventory(item);

        ApplyItemEffect(player, item);

        Destroy(gameObject);
    }
private void ApplyItemEffect(PlayerManager player, Item item)
{
    switch (item.type)
    {
        case ItemType.Health:

            player.maximumHealth += item.potency;
            player.currentHealth += item.potency;

            player.UpdateHealthDisplay();

            break;

        case ItemType.Damage:

            player.playerDamage += item.potency;

            break;

        case ItemType.Speed:

            player.baseSpeed += item.potency;

            break;
    }
}
}