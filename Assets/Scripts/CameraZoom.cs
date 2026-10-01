using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{

    [Header("Cinemachine Camera")]
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [Header("Zoom Settings")]
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float zoomSmoothSpeed = 10f;

    [Tooltip("Smallest FOV = most zoomed in")]
    [SerializeField] private float maxZoomIn = 25f;

    [Tooltip("Largest FOV = most zoomed out")]
    [SerializeField] private float maxZoomOut = 60f;

    private float targetFOV;

    private void Start()
    {

        if (cinemachineCamera == null)
        {
            cinemachineCamera = GetComponent<CinemachineCamera>();
        }

        targetFOV = cinemachineCamera.Lens.FieldOfView;
    }

    private void Update()
    {

        HandleZoom();
        SmoothZoom();
    }

    private void HandleZoom()
    {

        if (Mouse.current == null)
            return;

        float scroll = Mouse.current.scroll.ReadValue().y;

        if (Mathf.Abs(scroll) < 0.01f)
            return;

        // Scroll up = zoom in
        // Scroll down = zoom out
        targetFOV -= scroll * zoomSpeed;

        targetFOV = Mathf.Clamp(
            targetFOV,
            maxZoomIn,
            maxZoomOut
        );
    }

    private void SmoothZoom()
    {

        float currentFOV = cinemachineCamera.Lens.FieldOfView;

        float newFOV = Mathf.Lerp(

            currentFOV,
            targetFOV,
            zoomSmoothSpeed * Time.deltaTime
        );

        cinemachineCamera.Lens.FieldOfView = newFOV;
    }
}