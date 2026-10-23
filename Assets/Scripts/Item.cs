using UnityEngine;

[System.Serializable]

public class Item
{
    /*To Do List:
        -List out the item types and their functionalities here:
            -
        
        -Create a tag system for if those items affect the player, the core cubicle, or the towers? (Optional, requires discussion)
    */
    public string type; //Helps in identifying what stat to change

    public string name;

    public int potency;

    public int itemCount;
    //We could either store the itemCount that will appear in the Inventory in the item itself or...

    public Sprite itemSprite;

    //spriteRenderer = GetComponent<SpriteRenderer>();
    //itemSprite = spriteRenderer.sprite; This might have to be in the Gameobject since it inherits from monobehavior...? or written differently

    public Item() 
    {
        name = "Empty";
        itemCount = 0;
    }

    public void Add() 
    {

    }
}