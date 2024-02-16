using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Log
{
    public GameObject projectile;
    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                           transform.position) <= chaseRadius
          && Vector3.Distance(target.position,
                              transform.position) > attackRadius

                              )
        {
            if (currentState != EnemyState.stagger)
            {
                Vector3 tempVector = target.transform.position - transform.position;
                GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                current.GetComponent<Projectile>().Lauch(tempVector);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else
        {
            anim.SetBool("wakeUp", false);
        }
    }
}
