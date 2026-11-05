using UnityEngine;

public class TowerPrinter : Tower
{
    public float attackCooldown;
    public float maxCooldown;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float projectileSpeed = 10f;

    public void Start()
    {
        attackCooldown = 0;
    }

    public override void TowerBehavior()
    {
        if (attackCooldown >= maxCooldown)
        {
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

                rb.linearVelocity = transform.forward * projectileSpeed;
            }

            attackCooldown = 0;
            //Debug.Log("SHOOT");

        } else
        {
            attackCooldown += Time.deltaTime;
        }
    }
}
