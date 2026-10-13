using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool isCarrying = false;
    public float pickupRange;
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
        if (Keyboard.current.zKey.isPressed) { Pickup(); }

        if (isCarrying) { 
            DetermineCarryPointPos();
            if (heldTower != null)
            {
                heldTower.transform.position = carryPoint.position;
            }

            //When clicking, place tower at designated position
            if (Mouse.current.leftButton.wasPressedThisFrame) { PlaceTower(); }
        }
    }

    public void Pickup()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, pickupRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out Tower towerObj))
            {
                towerObj.SetState(Tower.TowerState.Carried);
                heldTower = towerObj;
                break;
            }
        }

        isCarrying = true;
        shootScript.enabled = false;
    }

    public void PlaceTower()
    {
        heldTower.SetState(Tower.TowerState.Active);
        isCarrying = false;
        shootScript.enabled = true;
    }

    public void DetermineCarryPointPos()
    {
        // Get mouse position
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Create a ray from the camera through the mouse
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        // Create a horizontal X/Z plane at the player's Y position
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0f, transform.position.y, 0f));

        // Check where the mouse ray hits the plane
        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);
            carryPoint.position = mouseWorldPosition;
        }
    }
}
