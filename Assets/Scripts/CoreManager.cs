using UnityEngine;
using System.Collections.Generic;

public class CoreManager : MonoBehaviour, IInteractable 
{
    public float coreCurrentHP;
    public float coreMaxHP;

    public Inventory playerInventory; //objects will be placed on the core, and 
    public GameObject effectRadius;

    public enum Abilities { NoBoost, RegenBoost, SpeedBoost, FireRateBoost };

    public Abilities coreAttributes = Abilities.NoBoost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        
    }

    public void BoostPlayerRegen()
    {
        
    }

    public void AutoFire()
    {
        
    }
}
