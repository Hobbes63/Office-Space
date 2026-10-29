using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item Pool")]
    public List<GameObject> possibleItems;

    [Header("Spawn Point")]
    public Transform itemSpawnPoint;

    private GameObject currentItem;

    public void SpawnRandomItem()
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        int randomIndex = Random.Range(0, possibleItems.Count);

        currentItem = Instantiate(
            possibleItems[randomIndex],
            itemSpawnPoint.position,
            Quaternion.identity
        );
    }
}