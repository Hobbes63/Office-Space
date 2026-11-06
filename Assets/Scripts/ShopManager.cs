using UnityEngine;

public class ShopManager : MonoBehaviour, IInteractable
{
    public GameObject shopUI;
    public Transform towerSpawnPoint;

    public void Interact()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    public void BuyTower(Tower towerPrefab)
    {
        if (towerPrefab == null)
        {
            Debug.LogError("Tower prefab is null!");
            return;
        }

        // Check if player has enough money
        if (MoneyManager.Instance.currentMoney < towerPrefab.price)
        {
            Debug.Log("Not enough money! Need $" + towerPrefab.price);
            return;
        }

        // Spend money
        MoneyManager.Instance.currentMoney -= towerPrefab.price;

        // Spawn tower
        GameObject newTower = Instantiate(
            towerPrefab.gameObject,
            towerSpawnPoint.position,
            towerSpawnPoint.rotation
        );

        // Optional: activate tower immediately
        Tower tower = newTower.GetComponent<Tower>();
        if (tower != null)
        {
            tower.SetState(Tower.TowerState.Active);
        }

        Debug.Log(
            "Purchased tower for $" +
            towerPrefab.price +
            ". Remaining money: $" +
            MoneyManager.Instance.currentMoney
        );
    }
}