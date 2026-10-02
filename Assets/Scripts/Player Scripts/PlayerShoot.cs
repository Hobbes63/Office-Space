using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    /*To Do List:
        -allow the projectilePrefab to pull from an array of possible projectiles to make some of the passive items work
        -
    */

    [Header("Shooting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Shoot();
        }
    }

    private void Shoot()
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

            // Calculate direction from FirePoint to mouse
            Vector3 direction = mouseWorldPosition - firePoint.position;

            // Keep projectile on the X/Z plane
            direction.y = 0f;

            direction.Normalize();

            // Create projectile
            GameObject projectile = Instantiate(

                projectilePrefab,
                firePoint.position,
                Quaternion.identity
            );

            // Give projectile velocity
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {

                rb.linearVelocity = direction * projectileSpeed;
            }
        }
    }
}