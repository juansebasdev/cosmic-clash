using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy : BaseEnemy
{
    [SerializeField] private float _projectileSpeed;

    public override void Shoot()
    {
        if (transform.position.y > _playerTransform.position.y)
        {
            GameObject projectile = EnemyProjectilePooler.Instance.GetPreloadObject();
            if (projectile != null)
            {
                // Vector2 direction = (_playerTransform.position - transform.position).normalized;
                // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                // float offset = 90f;

                projectile.SetActive(true);
                projectile.transform.position = transform.position;
                // projectile.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }
        }
    }
}
