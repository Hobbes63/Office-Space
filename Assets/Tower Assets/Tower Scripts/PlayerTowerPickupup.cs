using System.Xml.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Pickup variables")]
    public bool isCarrying = false;
    public float pickupRange;
    public float placementRange;

    [Header("References")]
    public Transform carryPoint;
    public MonoBehaviour shootScript;
    public Tower heldTower = null;
    void Start()
    {
        isCarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When K key is pressed, pick up tower
        if (Input.GetKeyDown(KeyCode.Z)) { Pickup(); }

        if (isCarrying) { 
            //Position carrypoint along ground and send tower there
            DetermineCarryPointPos();
            if (heldTower != null)
            {
                heldTower.transform.position = carryPoint.position;

                //When R key is pressed, rotate tower by 90 degrees
                if (Input.GetKeyDown(KeyCode.R)) { RotateTower(); }

                //When clicking, place tower at designated position
                if (Mouse.current.leftButton.wasPressedThisFrame) { PlaceTower(); }
            }
        }
    }

    public void Pickup()
    {
        float smallestDistance = float.MaxValue;
        Tower closestTower = null;

        //Compile all colliders within overlap sphere
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, pickupRange);

        //Check distance of all colliders that are towers to player, and determine closest
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out Tower tower))
            {
                //Get distance from player
                float tempDistance = Vector3.Distance(transform.position, collider.transform.position);

                //Check if smaller than current smallest distance
                if (tempDistance < smallestDistance)
                {
                    smallestDistance = tempDistance;
                    closestTower = tower;
                } 
            }
        }

        //If a closest Tower was found, set to held tower. Otherwise, stop.
        if (closestTower != null)
        {
            closestTower.SetState(Tower.TowerState.Carried);
            heldTower = closestTower;
        } else
        {
            return;
        }

        //set carrying to true
        isCarrying = true;

        //Disable shooting
        shootScript.enabled = false;
    }

    public void RotateTower()
    {
        //rotate held tower 90 degrees
        heldTower.transform.Rotate(0, 90, 0);
    }

    public void PlaceTower()
    {
        //TODO: add check for if placement point is within terrain

        //Get the distance from carrypoint and check it is within placement range
        float placementDistance = Vector3.Distance(this.transform.position, carryPoint.position);
        if (placementDistance <= placementRange)
        {
            //Set tower back to active state
            heldTower.SetState(Tower.TowerState.Active);

            //set carrying to false
            isCarrying = false;

            //Enable shooting
            shootScript.enabled = true;
        }
        else
        {
            //Replace later with some sort of visual effect
            Debug.Log("Too far to place tower");
        }
    }

    public void DetermineCarryPointPos()
    {
        // Get mouse position
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Create a ray from the camera through the mouse
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Create a horizontal X/Z plane at the player's Y position
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0f, 0f, 0f));

        // Check where the mouse ray hits the plane
        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);
            carryPoint.position = mouseWorldPosition;
            
        }
    }
}
