using UnityEngine;
using System.Collections;

public class AxisSystemRotation : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Camera.main != null)
        {
            Transform cameraParent = Camera.main.gameObject.transform.parent;

            if (cameraParent != null)
            {
                this.gameObject.transform.localRotation = cameraParent.localRotation;
            }
        }	
	}
}
