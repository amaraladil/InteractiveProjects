using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolLogs : logScript
{
    public Transform[] path;
    public int currentPath;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDIstance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                ChangeAnim(temp - transform.position);
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);

            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPath].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPath].position, moveSpeed * Time.deltaTime);
                myRigidBody.MovePosition(temp);
                ChangeAnim(temp - transform.position);
            } else
            {
                ChangeGoal();
            }
                
        }
    }

    public void ChangeGoal()
    {
        if(currentPath == path.Length - 1)
        {
            currentPath = 0;
            currentGoal = path[0];
        } else
        {
            currentPath++;
            currentGoal = path[currentPath];
        }
    }
}
