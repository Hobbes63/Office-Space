using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> itemPrefabs;

    [SerializeField]
    private Transform spawnPoint;

    private GameObject currentItem;

    public void SpawnRandomItem()
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        if (itemPrefabs.Count == 0)
            return;

        int randomIndex =
            Random.Range(0, itemPrefabs.Count);

        currentItem = Instantiate(
            itemPrefabs[randomIndex],
            spawnPoint.position,
            Quaternion.identity
        );
    }

    private void Start()
    {
        SpawnRandomItem();
    }
}