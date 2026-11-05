using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public List<GameObject> itemPrefabs = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetRandomItem()
    {
        if (itemPrefabs.Count == 0)
        {
            Debug.LogWarning("No items added to ItemManager!");
            return null;
        }

        int randomIndex =
            Random.Range(0, itemPrefabs.Count);

        return itemPrefabs[randomIndex];
    }
}
