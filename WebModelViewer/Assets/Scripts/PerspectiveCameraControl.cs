using UnityEngine;
using System.Collections;

public class PerspectiveCameraControl : MonoBehaviour
{
    public bool enabledOnStart = true;

    private bool rotatingCamera = false;
    private bool scrollingCamera = false;
    private bool zoomingCamera = false;

    private Vector3 lastMousePos = Vector3.zero;
    private Vector3 currentRotation = Vector3.zero;

    private Vector3 spawnPosition = Vector3.zero;
    private Vector3 spawnScale = Vector3.one;

	// Use this for initialization
	void Start ()
    {
        this.gameObject.SetActive(this.enabledOnStart);
        this.currentRotation = this.gameObject.transform.rotation.eulerAngles;
        this.spawnPosition = this.gameObject.transform.localPosition;
        this.spawnScale = this.gameObject.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Get relative mouse movement
        Vector3 relativeMouseMovement = Input.mousePosition - this.lastMousePos;
        relativeMouseMovement.z = Input.GetAxis("Mouse ScrollWheel");
        this.lastMousePos = Input.mousePosition;

        // Get current keyboard flags
        if (Input.GetMouseButton(2))
        {
            this.scrollingCamera = true;
            this.zoomingCamera = false;
            this.rotatingCamera = false;
        }
        else if (Input.GetMouseButton(0))
        {
            this.scrollingCamera = false;
            this.zoomingCamera = false;
            this.rotatingCamera = false;

            if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            {
                this.rotatingCamera = true;
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
                this.rotatingCamera = true;
            }
        }
        else
        {
            this.scrollingCamera = false;
            this.zoomingCamera = false;
            this.rotatingCamera = false;
        }


        // Zoom camera
        if (relativeMouseMovement.z != 0 || (this.zoomingCamera && relativeMouseMovement.y != 0))
        {
            float totalZoom = 0.0f;

            float zoomWheel = relativeMouseMovement.z * 10.0f;
            float zoomButton = 0.0f;

            if (this.zoomingCamera)
                zoomButton = relativeMouseMovement.y * 0.025f;

            totalZoom = zoomWheel + zoomButton;

            this.gameObject.transform.localScale = new Vector3(
                this.gameObject.transform.localScale.x,
                this.gameObject.transform.localScale.y,
                Mathf.Max(0.02f, this.gameObject.transform.localScale.z - totalZoom));
        }

        // Rotate camera
        if (this.rotatingCamera && (relativeMouseMovement.x != 0 || relativeMouseMovement.y != 0))
        {
            float rotateX = -relativeMouseMovement.y * 0.2f;
            float rotateY = relativeMouseMovement.x * 0.25f;
            
            this.currentRotation.x += rotateX;
            this.currentRotation.y += rotateY;
            Quaternion newRotation = new Quaternion();
            newRotation.eulerAngles = this.currentRotation;
            this.gameObject.transform.localRotation = newRotation;
        }

        // Scroll camera
        if (this.scrollingCamera && (relativeMouseMovement.x != 0 || relativeMouseMovement.y != 0))
        {
            float scrollY = -relativeMouseMovement.y * 0.005f;
            float scrollX = -relativeMouseMovement.x * 0.005f;

            Vector3 currentPosition = this.gameObject.transform.position;
            currentPosition += (scrollX * this.gameObject.transform.right) + (scrollY * this.gameObject.transform.up);
            this.gameObject.transform.position = currentPosition;
        }

        // Reset camera focus on button press
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.transform.localPosition = this.spawnPosition;
            this.gameObject.transform.localScale = this.spawnScale;
        }
    }
}
