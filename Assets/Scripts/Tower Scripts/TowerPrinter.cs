using UnityEngine;

public class TowerPrinter : Tower
{
    public float attackCooldown;
    public float maxCooldown;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public void Start()
    {
        attackCooldown = 0;
    }

    public override void TowerBehavior()
    {
        if (attackCooldown >= maxCooldown)
        {
            //TODO: Have tower create projectile, also create the prefab for this tower's projectile.

            attackCooldown = 0;
            Debug.Log("SHOOT");
        } else
        {
            attackCooldown += Time.deltaTime;
        }
    }
}
