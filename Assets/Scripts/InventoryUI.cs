using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject iconPrefab;
    public Transform iconParent;

    public void AddItem(Sprite itemSprite)
    {
        GameObject icon =
            Instantiate(iconPrefab, iconParent);

        icon.GetComponent<Image>().sprite =
            itemSprite;
    }
}