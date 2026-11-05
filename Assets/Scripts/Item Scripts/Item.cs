using UnityEngine;

public enum ItemType
{
    Health,
    Damage,
    Speed,
    FireRate,
    CoreHealth
}

[System.Serializable]
public class Item
{
    public string name;

    public ItemType type;

    public int potency;

    public int itemCount;

    public Sprite itemSprite;

    [TextArea]
    public string description;

    public Item()
    {
        name = "Empty";
        type = ItemType.Health;
        potency = 0;
        itemCount = 0;
        itemSprite = null;
        description = "";
    }
}