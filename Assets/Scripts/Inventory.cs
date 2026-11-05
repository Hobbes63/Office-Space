using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private int inventorySize = 100;

    public List<Item> playerInventory = new List<Item>();

    [Header("Audio")]
    [SerializeField] private AudioClip itemPickUp;

    [Header("Inventory UI")]
    [SerializeField] private Transform iconParent;
    [SerializeField] private GameObject iconPrefab;

    public void RefreshInventoryUI()
    {
        if (iconParent == null || iconPrefab == null)
        {
            Debug.LogWarning("Inventory UI references missing!");
            return;
        }

        foreach (Transform child in iconParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in playerInventory)
        {
            GameObject icon = Instantiate(iconPrefab, iconParent);

            InventoryIconUI iconUI =
                icon.GetComponentInChildren<InventoryIconUI>();

            if (iconUI == null)
            {
                Debug.LogError("InventoryIconUI missing!");
                continue;
            }

            iconUI.iconImage.sprite = item.itemSprite;
            iconUI.iconImage.color = Color.white;

            iconUI.countText.text =
                item.itemCount > 1 ? "x" + item.itemCount : "";
        }
    }

    public bool AddToInventory(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Cannot add a null item!");
            return false;
        }

        // Check for an existing matching item
        foreach (Item inventoryItem in playerInventory)
        {
            if (inventoryItem.name == item.name &&
                inventoryItem.type == item.type)
            {
                inventoryItem.itemCount++;

                Debug.Log($"Stacked {item.name}");

                PlayPickupSound();
                RefreshInventoryUI();

                return true;
            }
        }

        // Check inventory capacity
        if (playerInventory.Count >= inventorySize)
        {
            Debug.Log("Inventory Full!");
            return false;
        }

        // Add new item
        item.itemCount = 1;
        playerInventory.Add(item);

        Debug.Log($"Added {item.name}");

        PlayPickupSound();
        RefreshInventoryUI();

        return true;
    }

    public void RemoveFromInventory(Item item)
    {
        if (item == null)
            return;

        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (playerInventory[i].name == item.name &&
                playerInventory[i].type == item.type)
            {
                playerInventory[i].itemCount--;

                if (playerInventory[i].itemCount <= 0)
                {
                    playerInventory.RemoveAt(i);
                }

                RefreshInventoryUI();

                return;
            }
        }
    }

    public bool IsFull()
    {
        return playerInventory.Count >= inventorySize;
    }

    private void PlayPickupSound()
    {
        if (itemPickUp != null && SFXManager.instance != null)
        {
            SFXManager.instance.PlaySFXClip(
                itemPickUp,
                transform,
                1f
            );
        }
    }

    public List<Item> GetInventory()
    {
        return playerInventory;
    }
}
