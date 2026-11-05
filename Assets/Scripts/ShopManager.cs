using UnityEditor;
using UnityEngine;

public class ShopManager : MonoBehaviour, IInteractable
{
    public GameObject shopUI;
    public Transform towerSpawnPoint;
    public GameObject moneyManager;

    public void Interact()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    public void BuyTower(Tower towerPrefab)
    {
        // if (moneyManager has enough money)
        Instantiate(towerPrefab, towerSpawnPoint);
        // reduce money by cost variable above
    }
}