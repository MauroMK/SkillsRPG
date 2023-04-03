using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    private void Start() 
    {
        target = PlayerManager.instance.playerReference.transform;
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update() 
    {
        float distance = Vector3.Distance(target.position, transform.position);   

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the player

                // Face to the target
                FaceTarget();
            }
        } 
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;                          // Get a direction to the target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   // Get a rotation to point to the target
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);   // Smooth interpolate towards that rotation
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);    
    }
}
