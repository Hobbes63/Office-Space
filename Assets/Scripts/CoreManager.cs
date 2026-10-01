using UnityEngine;
using System.Collections.Generic;

public class CoreManager : MonoBehaviour
{
    public float coreCurrentHP;
    public float coreMaxHP;


    public GameObject effectRadius;

    public List<KeyValuePair<string, int>> Abilities;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        Abilities = new List<KeyValuePair<string, int>>
        {
            // new KeyValuePair<string, int>("", Mathf.RoundToInt(baseSpeed)),
            // new KeyValuePair<string, int>("", Mathf.RoundToInt(currentHealth)),
            // new KeyValuePair<string, int>("", shield),
            // new KeyValuePair<string, int>("", playerLives)

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoostPlayerRegen()
    {
        
    }

    public void AutoFire()
    {
        
    }
}
