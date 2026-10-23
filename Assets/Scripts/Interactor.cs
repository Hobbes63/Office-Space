using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //retooled to use overlapshere instead of raycast, detects all collisions around player instead of just in a specific direction
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            Collider[] hitColliders = Physics.OverlapSphere(InteractorSource.position, InteractRange);
            foreach(Collider collider in hitColliders)
            {
                if(collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                    return;
                }
            }
            /*
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) {
                    interactObj.Interact();
                }
            }
            */
        }
    }
}
