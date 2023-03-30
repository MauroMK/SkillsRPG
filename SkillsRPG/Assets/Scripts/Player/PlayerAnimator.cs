using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    private const float smoothTime = 0.1f;
    private Animator animator;
    private NavMeshAgent agent;
    private string animatorParameter = "SpeedPercent";

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercentage = agent.velocity.magnitude / agent.speed;
        animator.SetFloat(animatorParameter, speedPercentage, smoothTime, Time.deltaTime);
    }
}
