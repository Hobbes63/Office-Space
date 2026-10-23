using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TowerState { Inactive, Active, Carried }

    [Header("Tower variables")]
    public TowerState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Towers spawn initially in an inactive state
        state = TowerState.Inactive;
    }

    // Update is called once per frame
    public void Update()
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
                break;
        }
    }

    public void SetState(TowerState newState)
    {
        state = newState;

        switch (state)
        {
            case TowerState.Inactive:
                this.GetComponent<Collider>().enabled = true;
                break;
            case TowerState.Active:
                this.GetComponent<Collider>().enabled = true;
                break;
            case TowerState.Carried:
                //Carried state has tower change apperance to be transparent.
                this.GetComponent<Collider>().enabled = false;
                break;
        }
    }

    public TowerState GetState()
    {
        return state;
    }

    public virtual void TowerBehavior()
    {
        //Will be overrided
    }
}
