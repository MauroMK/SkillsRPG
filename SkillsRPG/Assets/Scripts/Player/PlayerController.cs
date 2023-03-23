using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask movementMask;
    
    private PlayerMovement playerMovement;
    
    private int rayRange = 100;
    Camera cam;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        //* Left Mouse Button
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayRange, movementMask))
            {
                //Debug.Log("We hit " + hit.collider.name + " " + hit.point); if want to see where clicked

                //* Move the player
                playerMovement.MoveToPoint(hit.point);

                //* Stop focusing any object
            }

        }

        //* Right Mouse Button
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayRange, movementMask))
            {
                //* Check if hit an interactible
                //* If did, set it the focus
            }

        }
    }
}
