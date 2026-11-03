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
    foreach (Transform child in iconParent)
    {
        Destroy(child.gameObject);
    }

    foreach (Item item in playerInventory)
    {
        GameObject icon =
            Instantiate(iconPrefab, iconParent);

        Image image =
            icon.GetComponent<Image>();

        image.sprite = item.itemSprite;
    }
}

    public void AddToInventory(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Tried to add a null item!");
            return;
        }

        // Check if item already exists
        foreach (Item inventoryItem in playerInventory)
        {
            if (inventoryItem.name == item.name)
            {
                inventoryItem.itemCount++;
                Debug.Log($"Added another {item.name}");

                PlayPickupSound();

                RefreshInventoryUI();
                return;
            }
        }

        // Add as a new item
        if (playerInventory.Count < inventorySize)
        {
            item.itemCount = 1;
            playerInventory.Add(item);

            Debug.Log($"Added {item.name}");

            PlayPickupSound();
            
            RefreshInventoryUI();
        }
        else
        {
            Debug.Log("Inventory Full!");
        }
    }

    public void RemoveFromInventory(Item item)
    {
        if(item == null)
            return;

        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (playerInventory[i].name == item.name)
            {
                playerInventory[i].itemCount--;

                if (playerInventory[i].itemCount <= 0)
                {
                    playerInventory.RemoveAt(i);
                }

                break;
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