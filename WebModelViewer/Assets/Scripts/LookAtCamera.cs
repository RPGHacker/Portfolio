using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    private Transform targetCameraTransform = null;

	// Use this for initialization
	void Start ()
    {
        this.gameObject.transform.parent = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (this.targetCameraTransform != null)
        {
            this.gameObject.transform.LookAt(this.gameObject.transform.position + (this.gameObject.transform.position - this.targetCameraTransform.position), this.targetCameraTransform.up);
        }
	}

    void OnRenderObject()
    {
        if (this.targetCameraTransform == null && Camera.current != null && Camera.current.gameObject.CompareTag("AxisSystemCamera") && ((Camera.current.cullingMask & (1 << this.gameObject.layer)) != 0))
        {
            this.targetCameraTransform = Camera.current.gameObject.transform;
        }
    }
}
