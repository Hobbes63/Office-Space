using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TowerState { Inactive, Active, Carried }

    [Header("Tower variables")]
    public TowerState state;

    [Header("Player variables")]
    public Transform carryPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Towers spawn initially in an inactive state
        state = TowerState.Inactive;
    }

    // Update is called once per frame
    void Update()
    {
        //Check state of tower
        switch (state)
        {
            case TowerState.Inactive:
                break;
            case TowerState.Active:
                TowerBehavior();
                break;
            case TowerState.Carried:
                //Move tower to carry point while it is being carried
                this.transform.position = carryPoint.position;
                break;
        }
    }

    public void Pickup()
    {
        state = TowerState.Carried;
    }

    public void TowerBehavior()
    {
        //Will be overwritten by subclasses with specific tower behavior
    }
}
