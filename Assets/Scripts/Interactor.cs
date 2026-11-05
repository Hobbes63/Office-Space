using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    
    void Update()
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
        }
    }
}