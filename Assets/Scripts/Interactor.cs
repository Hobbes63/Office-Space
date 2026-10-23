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

    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask interactableLayer;
    private void Update()
    {
        Debug.DrawRay(
            InteractorSource.position,
            InteractorSource.forward * InteractRange,
            Color.green
        );

        if (!Input.GetKeyDown(interactKey))
            return;

        Ray ray = new Ray(
            InteractorSource.position,
            InteractorSource.forward
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            InteractRange,
            interactableLayer))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            interactable?.Interact();
        }
    }
}
