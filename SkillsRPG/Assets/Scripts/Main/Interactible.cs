using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;

    public bool hasInteracted = false;
    bool isFocus = false;

    Transform player;
    public Transform interactionTransform;

    public virtual void Interact()
    {
        // This method is meant to be overrited
        // Debug.Log("Interacting with " + transform.name);
    }

    void Update() 
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                // hasInteracted variable is meant to be used inside each Interact function of the interactible object
            }
        }    
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    public void OnDrawGizmosSelected() 
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;    
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
