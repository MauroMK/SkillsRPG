using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;

    public void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;    
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
