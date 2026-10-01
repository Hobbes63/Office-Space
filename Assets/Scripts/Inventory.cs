using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Xml.Serialization;
using System.IO;
using System;

public class Inventory : MonoBehaviour
{
    public bool showingInventory;

    public string menuName;

    //public GameObject[] fullInventoryItems;
    //public GameObject[] quickInventoryItems;

    Item nullItem;
    Item selectedItem;

    // These are both unnecessary for this system structure.
    // private int inventorySlotsMin = 6; //Only show 6 item SLOTS at first, and once that is reached...
    // public int inventorySlotsMax = 12; //Show 12 item slots

    List<Item> inventory = new List<Item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] public GameObject Player;

    [SerializeField] public AudioClip item_PickUp;

    [SerializeField] public List<Item> playerInventory = new List<Item>();
    void Start()
    {
        menuName = "Inventory";
        nullItem = new Item();
        nullItem.name = "Empty";
        nullItem.itemCount = 0;

        InitializeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showingInventory = (showingInventory) ? true : false; //Instead make it so the items can be made larger and hoverable with their info
        }

    }

    public void AddToInventory(Item item) 
    {
        if (!isFull()) 
        {
            for (int i = 0; i < inventory.Count; i++) 
            {
                if (inventory[i].name != "Empty")
                {
                    if (inventory[i].name == item.name)
                    {
                        //Add a recurring item to a stack of item stored in the item
                        inventory[i].itemCount += 1;
                        break;
                    }
                }
                else if (inventory[i].name == "Empty") 
                {
                    //Add a new item to the list
                    inventory[i] = item;
                    break;
                }
            }
        }

        SFXManager.instance.PlaySFXClip(item_PickUp, this.transform, 1f);
    }

    void InitializeInventory()
    {
        inventory = new List<Item>();
        // quickInventory = new List<Item>(); 
        // for (int i = 0; i < inventoryMax; i++)
        // {
        //     inventory.Add(nullItem);


        //     if (i < quickInventoryMax) 
        //     {
        //         quickInventory.Add(nullItem);
        //         quickInventoryButtons[i].text = quickInventory[i].name + " " + quickInventory[i].itemCount;
        //     }
            //itemCount.Add(new KeyValuePair<int, Item>(0, emptyObject));
                //emptyObject should perhaps be an empty "Item" instead of a gameObject (also no longer using this framework)
                
        //}
    }
    public void RemoveFromInventory(Item thisItem)
    {
        // int quickSlot = 0;
        // bool isInQuickSlot = false;

        // for (int i = 0; i < quickInventoryMax; i++) 
        // {
        //     if (quickInventory[i].name  == thisItem.name)
        //     {
        //         isInQuickSlot = true;
        //         quickSlot = i;
        //         break;
        //     }


        // }

        for (int i = 0; i < inventory.Count; i++)
        {

            //if (i < quickInventoryMax)
            //{
            //    Debug.Log(i);
            //    Debug.Log(quickInventory[i].name);
            //    if (quickInventory[i].name != "Empty")
            //    {
            //        if (quickInventory[i].name.Equals(thisItem.name))
            //        {
            //            quickInventory[i].itemCount -= 1;

            //            if (quickInventory[i].itemCount <= 0)
            //            {
            //                quickInventory[i] = nullItem;
            //            }
            //        }
            //    }

            //    quickInventoryButtons[i].text = quickInventory[i].name + " " + quickInventory[i].itemCount;
            //}

            if (inventory[i].name != "Empty")
            {
                if (inventory[i].name == thisItem.name)
                {
                    inventory[i].itemCount -= 1;

                    // if (isInQuickSlot) 
                    // {
                    //     quickInventory[quickSlot].itemCount = inventory[i].itemCount;

                    //     quickInventoryButtons[quickSlot].text = quickInventory[quickSlot].name + " " + quickInventory[quickSlot].itemCount;
                    // }

                    if (inventory[i].itemCount <= 0) 
                    {
                        inventory.RemoveAt(i);
                        inventory.Add(nullItem);

                        // if (isInQuickSlot) 
                        // {
                        //     quickInventory[quickSlot] = nullItem;

                        //     quickInventoryButtons[quickSlot].text = quickInventory[quickSlot].name + " " + quickInventory[quickSlot].itemCount;
                        // }
                    }
                    break;
                }
            } 
        }  
    }

    public bool isFull()
    {
        //int slotTaken = 0;

        // for (int i = 0; i < inventory.Count; i++)
        // {
        //     if (inventory[i].name != "Empty")
        //         slotTaken++;
        // }

        // if (slotTaken >= inventorySlotsMax)
        // {
        //     Debug.Log("Inventory Full!");
        //     return true;
        // }
        // else 
        // {
        //     //Debug.Log("Got more space in here!");
        //     return false;
        // }

        return false;
    }
}
