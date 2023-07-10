using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask movementMask;
    public Interactible focus;

    #region References
    private PlayerMovement playerMovement;
    Camera cam;
    #endregion

    private int rayRange = 100;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        // Check if is hovering UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Left Mouse Button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, rayRange, movementMask))
            {
                // Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                // Move the player
                playerMovement.MoveToPoint(hit.point);

                // Stop focusing any object
                RemoveFocus();

                // If the ray hits
                if (Physics.Raycast(ray, out hit, rayRange))
                {
                    // Check if hit an interactible
                    Interactible interactible = hit.collider.GetComponent<Interactible>();

                    // If did, set it the focus
                    if (interactible != null)
                    {
                        SetFocus(interactible);
                    }
                }
            }

        }

        // Right Mouse Button
        if (Input.GetMouseButtonDown(1))
        {
            //TODO Right button mouse will examine the objects, and show the options to do

            // Create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, rayRange))
            {
                // Check if hit an interactible
                Interactible interactible = hit.collider.GetComponent<Interactible>();

                // If did, set it the focus
                if (interactible != null)
                {
                    SetFocus(interactible);
                }
            }

        }
    }

    // Focus on a interactible object
    void SetFocus(Interactible newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            playerMovement.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
        
    }

    // Removes the focus
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        
        focus = null;
        playerMovement.StopFollowingTarget();
    }
}
