using UnityEngine;

public class
 Projectile : MonoBehaviour
{

    [Header("Projectile Settings")]
    [SerializeField] private float lifetime = 3f;

    private void Start()
    {

        // Destroy the projectile after the set amount of time
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {

        // Only interact with objects tagged "Enemy"
        if (other.CompareTag("Enemy"))
        {

            // Destroy the enemy
            Destroy(other.gameObject);

            // Destroy the projectile
            Destroy(gameObject);
        }

        // Only interact with objects tagged "Enemy"
        if (other.CompareTag("Terrain"))
        {

            // Destroy the projectile
            Destroy(gameObject);
        }

    }
}