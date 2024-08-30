using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform Weapon;
    [SerializeField] Transform Target;
    [SerializeField] float Range = 15f;
    [SerializeField] ParticleSystem ArrowProjectile;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        FindCloseTarget();
        AimWeapon();
    }

    void FindCloseTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform ClosestTarget = null;
        float MaxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float TargetDistance = Vector3.Distance(transform.position , enemy.transform.position);

            if(TargetDistance < MaxDistance)
            {
                ClosestTarget = enemy.transform;
                MaxDistance = TargetDistance;
            }
        }

        Target = ClosestTarget;
    }

    void AimWeapon()
    {
        
        float TargetDistance = Vector3.Distance (transform.position , Target.position);

        

        if (TargetDistance < Range)
        {
            Weapon.LookAt(Target);
            Attack(true);

        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = ArrowProjectile.emission;
        emissionModule.enabled = isActive;
    }
}
