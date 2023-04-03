using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float zoomSpeed = 4f;

    #region Numbers
    private float minZoom = 5f;
    private float maxZoom = 15f;
    private float pitch = 2f;
    private float currentZoom = 10f;
    private float rotationSpeed = 100f;
    private float rotationInput = 0f;
    #endregion

    void Update() 
    {
        // Zoom
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Rotate the camera
        rotationInput -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
    }

    void LateUpdate() 
    {
        // Look at the player
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        // Rotate the camera
        transform.RotateAround(target.position, Vector3.up, rotationInput);
    }
}
