using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemType type;

    public string name;

    public int potency;

    public int itemCount;

    public Sprite itemSprite;

    public Item()
    {
        name = "Empty";
        itemCount = 0;
    }

public enum ItemType
{
    Health,
    Damage,
    Speed,
    FireRate,
    CoreHealth,
  
}

}