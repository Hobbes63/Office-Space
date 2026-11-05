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
    if (Input.GetKeyDown(KeyCode.E))
    {
        float smallestDistance = float.MaxValue;
        IInteractable closestObj = null;

        Collider[] hitColliders = Physics.OverlapSphere(InteractorSource.position, InteractRange);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {

                float tempDistance = Vector3.Distance(transform.position, collider.transform.position);

                if (tempDistance < smallestDistance)
                {
                    smallestDistance = tempDistance;
                    closestObj = interactObj;
                }
            }
        }

        if (closestObj != null)
        {
            closestObj.Interact();
        }
        else
        {
            return;
        }
    }
}
}