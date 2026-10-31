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

    private void Update()
    {
        Debug.DrawRay(
            interactorSource.position,
            interactorSource.forward * interactRange,
            Color.green
        );

        if (!Input.GetKeyDown(interactKey))
            return;

        Ray ray = new Ray(
            interactorSource.position,
            interactorSource.forward
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactRange,
            interactableLayer))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            interactable?.Interact();
        }
    }
}
