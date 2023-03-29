using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent navAgent;      // Reference to the agent
    Transform target;           // Target to follow

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update() 
    {
        // TODO maybe use coroutine to update the position a few times a second.

        if (target != null)
        {
            navAgent.SetDestination(target.position);   // If have a target, update the position of the agent to the target position every frame
            FaceTarget();
        }    
    }

    public void MoveToPoint(Vector3 pointToMove)
    {
        navAgent.SetDestination(pointToMove);
    }

    public void FollowTarget(Interactible newTarget)
    {
        navAgent.stoppingDistance = newTarget.radius * 0.8f;
        navAgent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget() 
    {
        navAgent.stoppingDistance = 0f;
        navAgent.updateRotation = true;

        target = null;
    }

    public void FaceTarget()
    {
        // Pick the direction you want to rotate at, quaternion creates a new vector3, and then slerps to be smooth
        Vector3 direction = (target.position - transform.position).normalized;                          // Get a direction towards our target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));   // Find out how to look at the direction (dont pick in the Y, because dont want to look up)
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);   // Smooth interpolate towards that rotation
    }
}
