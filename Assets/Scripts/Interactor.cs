
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform InteractorSource;
    public float InteractRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindClosestInteractable();
        }
    }

    private void FindClosestInteractable()
    {
        if (InteractorSource == null)
        {
            Debug.LogWarning("Interactor Source not assigned!");
            return;
        }

        float smallestDistance = float.MaxValue;
        IInteractable closestObj = null;

        Collider[] hitColliders = Physics.OverlapSphere(
            InteractorSource.position,
            InteractRange
        );

        foreach (Collider collider in hitColliders)
        {
            IInteractable interactObj =
                collider.GetComponentInParent<IInteractable>();

            if (interactObj != null)
            {
                float distance = Vector3.Distance(
                    InteractorSource.position,
                    collider.ClosestPoint(InteractorSource.position)
                );

                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestObj = interactObj;
                }
            }
        }

        if (closestObj != null)
        {
            closestObj.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (InteractorSource == null)
            return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            InteractorSource.position,
            InteractRange
        );
    }
}
