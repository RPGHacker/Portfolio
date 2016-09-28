using UnityEngine;
using System.Collections;

public class OrthographicCameraControl : CameraBase
{
    private bool scrollingCamera = false;
    private bool zoomingCamera = false;

    private Vector3 lastMousePos = Vector3.zero;

    private Vector3 spawnPosition = Vector3.zero;
    private Vector3 cameraSpawnWorldPosition = Vector3.zero;
    private float spawnScale = 1.0f;

    private Camera attachedCamera = null;

    public override Vector3 GetWorldSpawnPosition()
    {
        return this.cameraSpawnWorldPosition;
    }

    // Use this for initialization
    void Start ()
    {
        this.attachedCamera = this.GetComponentInChildren<Camera>();

        this.spawnPosition = this.gameObject.transform.localPosition;

        if (this.attachedCamera != null)
        {
            this.spawnScale = this.attachedCamera.orthographicSize;
            this.cameraSpawnWorldPosition = this.attachedCamera.gameObject.transform.position;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.attachedCamera == null)
            this.attachedCamera = Camera.main;

        // Get relative mouse movement
        Vector3 relativeMouseMovement = Input.mousePosition - this.lastMousePos;
        relativeMouseMovement.z = Input.GetAxis("Mouse ScrollWheel");
        this.lastMousePos = Input.mousePosition;

        // Get current keyboard flags
        if (Input.GetMouseButton(2))
        {
            this.scrollingCamera = true;
            this.zoomingCamera = false;
        }
        else if (Input.GetMouseButton(0))
        {
            this.scrollingCamera = false;
            this.zoomingCamera = false;

            if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            {
                this.scrollingCamera = true;
            }
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                this.scrollingCamera = true;
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                this.zoomingCamera = true;
            }
            else
            {
                this.scrollingCamera = true;
            }
        }
        else
        {
            this.scrollingCamera = false;
            this.zoomingCamera = false;
        }

        // Zoom camera
        if (relativeMouseMovement.z != 0 || (this.zoomingCamera && relativeMouseMovement.y != 0))
        {
            float totalZoom = 0.0f;

            float zoomWheel = relativeMouseMovement.z * 2.0f;
            float zoomButton = 0.0f;

            if (this.zoomingCamera)
                zoomButton = relativeMouseMovement.y * 0.005f;

            totalZoom = zoomWheel + zoomButton;

            if (this.attachedCamera != null)
                this.attachedCamera.orthographicSize = Mathf.Max(0.1f, this.attachedCamera.orthographicSize - totalZoom);
        }

        // Scroll camera
        if (this.scrollingCamera && (relativeMouseMovement.x != 0 || relativeMouseMovement.y != 0))
        {
            float scrollSpeedFactor = 1.0f;

            if (this.attachedCamera != null)
                scrollSpeedFactor = this.attachedCamera.orthographicSize / this.spawnScale;

            float scrollY = -relativeMouseMovement.y * 0.005f * scrollSpeedFactor;
            float scrollX = -relativeMouseMovement.x * 0.005f * scrollSpeedFactor;

            Vector3 currentPosition = this.gameObject.transform.position;
            currentPosition += (scrollX * this.gameObject.transform.right) + (scrollY * this.gameObject.transform.up);
            this.gameObject.transform.position = currentPosition;
        }

        // Reset camera focus on button press
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.transform.localPosition = this.spawnPosition;
            if (this.attachedCamera != null)
                this.attachedCamera.orthographicSize = this.spawnScale;
        }
    }
}
