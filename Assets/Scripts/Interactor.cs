using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask interactableLayer;

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
