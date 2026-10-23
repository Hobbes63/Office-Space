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
