using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ViewportGridRenderer : MonoBehaviour
{
    public float gridScale = 1.0f;
    public int numberOfMajorSections = 5;
    public int numberOfSubSections = 10;
    public Material lineMaterial = null;
    public Color majorGridColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    public Color subGridColor = new Color(1.0f, 1.0f, 1.0f, 0.25f);

    private ViewportControlsGUI viewportControls = null;

    // Use this for initialization
    void Start()
    {
        this.SetValueLimits();
    }

    void Awake()
    {
        this.SetValueLimits();
    }
	
	// Update is called once per frame
	void Update()
    {
        this.SetValueLimits();
    }

    void SetValueLimits()
    {
        gridScale = Mathf.Clamp(gridScale, 0.0f, 10000.0f);
        numberOfMajorSections = Mathf.Clamp(numberOfMajorSections, 0, 100);
        numberOfSubSections = Mathf.Clamp(numberOfSubSections, 0, 100);
    }

    // Is called when the object is rendered
    void OnRenderObject()
    {
        this.viewportControls = this.GetComponent<ViewportControlsGUI>();

        if (this.viewportControls != null && !this.viewportControls.renderGrid)
            return;

        Camera currentCamera = Camera.current;

        if (currentCamera != null)
        {
            if ((currentCamera.cullingMask & (1 << this.gameObject.layer)) == 0)
                return;
        }

        if (lineMaterial != null)
            lineMaterial.SetPass(0);

        float subSectionStrength = 1.0f;
        Color currentSubColor = this.subGridColor;

        // Get distance of camera from grid to determine how strong sub sections should be rendered
        if (currentCamera != null)
        {
            if (currentCamera.orthographic)
            {
                // Orthographic camera
                const float thresholdMin = 2.0f;
                const float thresholdMax = 5.0f;

                if (Mathf.Abs(currentCamera.orthographicSize) < thresholdMin)
                    subSectionStrength = 1.0f;
                else if (Mathf.Abs(currentCamera.orthographicSize) > thresholdMax)
                    subSectionStrength = 0.0f;
                else
                    subSectionStrength = 1.0f - ((Mathf.Abs(currentCamera.orthographicSize) - thresholdMin) / (thresholdMax - thresholdMin));
            }
            else
            {
                // Perspective camera
                const float thresholdMin = 1.0f;
                const float thresholdMax = 7.5f;

                if (Mathf.Abs(currentCamera.gameObject.transform.position.y) < thresholdMin)
                    subSectionStrength = 1.0f;
                else if (Mathf.Abs(currentCamera.gameObject.transform.position.y) > thresholdMax)
                    subSectionStrength = 0.0f;
                else
                    subSectionStrength = 1.0f - ((Mathf.Abs(currentCamera.gameObject.transform.position.y) - thresholdMin) / (thresholdMax - thresholdMin));
            }
        }

        currentSubColor.a *= subSectionStrength;

        // Get grid render parameters
        CameraViewPlane gridPlane = CameraViewPlane.XZPlane;
        Vector3 gridCenter = Vector3.zero;

        if (Camera.main != null && Application.isPlaying)
        {
            CameraBase cameraScript = Camera.main.gameObject.transform.parent.gameObject.GetComponentInChildren<CameraBase>();

            if (cameraScript != null)
                gridPlane = cameraScript.viewPlane;

            if (Camera.main.orthographic)
            {
                gridCenter = -cameraScript.GetWorldSpawnPosition();
            }
        }

        // Render grid
        if (gridScale > 0.0f && gridScale < 10000.0f)
        {
            float numMajorSectionsApplied = (float)(numberOfMajorSections) * gridScale;

            float xOffsetFrom = 0.0f;
            float xOffsetTo = 0.0f;
            float yOffsetFrom = 0.0f;
            float yOffsetTo = 0.0f;
            float zOffsetFrom = 0.0f;
            float zOffsetTo = 0.0f;

            // First axis
            for (float firstAxis = -numMajorSectionsApplied; firstAxis <= numMajorSectionsApplied; firstAxis += (1.0f * gridScale))
            {
                if (firstAxis < numMajorSectionsApplied)
                {
                    for (float fraction = 0.0f; fraction <= 1.0f; fraction += (1.0f / (float)(numberOfSubSections)))
                    {
                        float offset = fraction * gridScale;

                        switch (gridPlane)
                        {
                            case CameraViewPlane.XYPlane:
                                xOffsetFrom = firstAxis + offset;
                                xOffsetTo = firstAxis + offset;
                                yOffsetFrom = -numMajorSectionsApplied;
                                yOffsetTo = numMajorSectionsApplied;
                                zOffsetFrom = 0.0f;
                                zOffsetTo = 0.0f;
                                break;
                            case CameraViewPlane.XZPlane:
                                xOffsetFrom = firstAxis + offset;
                                xOffsetTo = firstAxis + offset;
                                zOffsetFrom = -numMajorSectionsApplied;
                                zOffsetTo = numMajorSectionsApplied;
                                yOffsetFrom = 0.0f;
                                yOffsetTo = 0.0f;
                                break;
                            case CameraViewPlane.YZPlane:
                                yOffsetFrom = firstAxis + offset;
                                yOffsetTo = firstAxis + offset;
                                zOffsetFrom = -numMajorSectionsApplied;
                                zOffsetTo = numMajorSectionsApplied;
                                xOffsetFrom = 0.0f;
                                xOffsetTo = 0.0f;
                                break;
                        }

                        GL.Begin(GL.LINES);
                        GL.Color(currentSubColor);
                        GL.Vertex(gridCenter + new Vector3(xOffsetFrom, yOffsetFrom, zOffsetFrom));
                        GL.Vertex(gridCenter + new Vector3(xOffsetTo, yOffsetTo, zOffsetTo));
                        GL.End();
                    }
                }


                switch (gridPlane)
                {
                    case CameraViewPlane.XYPlane:
                        xOffsetFrom = firstAxis;
                        xOffsetTo = firstAxis;
                        yOffsetFrom = -numMajorSectionsApplied;
                        yOffsetTo = numMajorSectionsApplied;
                        zOffsetFrom = 0.0f;
                        zOffsetTo = 0.0f;
                        break;
                    case CameraViewPlane.XZPlane:
                        xOffsetFrom = firstAxis;
                        xOffsetTo = firstAxis;
                        zOffsetFrom = -numMajorSectionsApplied;
                        zOffsetTo = numMajorSectionsApplied;
                        yOffsetFrom = 0.0f;
                        yOffsetTo = 0.0f;
                        break;
                    case CameraViewPlane.YZPlane:
                        yOffsetFrom = firstAxis;
                        yOffsetTo = firstAxis;
                        zOffsetFrom = -numMajorSectionsApplied;
                        zOffsetTo = numMajorSectionsApplied;
                        xOffsetFrom = 0.0f;
                        xOffsetTo = 0.0f;
                        break;
                }

                GL.Begin(GL.LINES);
                GL.Color(majorGridColor);
                GL.Vertex(gridCenter + new Vector3(xOffsetFrom, yOffsetFrom, zOffsetFrom));
                GL.Vertex(gridCenter + new Vector3(xOffsetTo, yOffsetTo, zOffsetTo));
                GL.End();
            }


            // Second axis
            for (float secondAxis = -numMajorSectionsApplied; secondAxis <= numMajorSectionsApplied; secondAxis += (1.0f * gridScale))
            {
                if (secondAxis < numMajorSectionsApplied)
                {
                    for (float fraction = 0.0f; fraction <= 1.0f; fraction += (1.0f / (float)(numberOfSubSections)))
                    {
                        float offset = fraction * gridScale;

                        switch (gridPlane)
                        {
                            case CameraViewPlane.XYPlane:
                                xOffsetFrom = -numMajorSectionsApplied;
                                xOffsetTo = numMajorSectionsApplied;
                                yOffsetFrom = secondAxis + offset;
                                yOffsetTo = secondAxis + offset;
                                zOffsetFrom = 0.0f;
                                zOffsetTo = 0.0f;
                                break;
                            case CameraViewPlane.XZPlane:
                                xOffsetFrom = -numMajorSectionsApplied;
                                xOffsetTo = numMajorSectionsApplied;
                                zOffsetFrom = secondAxis + offset;
                                zOffsetTo = secondAxis + offset;
                                yOffsetFrom = 0.0f;
                                yOffsetTo = 0.0f;
                                break;
                            case CameraViewPlane.YZPlane:
                                yOffsetFrom = -numMajorSectionsApplied;
                                yOffsetTo = numMajorSectionsApplied;
                                zOffsetFrom = secondAxis + offset;
                                zOffsetTo = secondAxis + offset;
                                xOffsetFrom = 0.0f;
                                xOffsetTo = 0.0f;
                                break;
                        }

                        GL.Begin(GL.LINES);
                        GL.Color(currentSubColor);
                        GL.Vertex(gridCenter + new Vector3(xOffsetFrom, yOffsetFrom, zOffsetFrom));
                        GL.Vertex(gridCenter + new Vector3(xOffsetTo, yOffsetTo, zOffsetTo));
                        GL.End();
                    }
                }


                switch (gridPlane)
                {
                    case CameraViewPlane.XYPlane:
                        xOffsetFrom = -numMajorSectionsApplied;
                        xOffsetTo = numMajorSectionsApplied;
                        yOffsetFrom = secondAxis;
                        yOffsetTo = secondAxis;
                        zOffsetFrom = 0.0f;
                        zOffsetTo = 0.0f;
                        break;
                    case CameraViewPlane.XZPlane:
                        xOffsetFrom = -numMajorSectionsApplied;
                        xOffsetTo = numMajorSectionsApplied;
                        zOffsetFrom = secondAxis;
                        zOffsetTo = secondAxis;
                        yOffsetFrom = 0.0f;
                        yOffsetTo = 0.0f;
                        break;
                    case CameraViewPlane.YZPlane:
                        yOffsetFrom = -numMajorSectionsApplied;
                        yOffsetTo = numMajorSectionsApplied;
                        zOffsetFrom = secondAxis;
                        zOffsetTo = secondAxis;
                        xOffsetFrom = 0.0f;
                        xOffsetTo = 0.0f;
                        break;
                }

                GL.Begin(GL.LINES);
                GL.Color(majorGridColor);
                GL.Vertex(gridCenter + new Vector3(xOffsetFrom, yOffsetFrom, zOffsetFrom));
                GL.Vertex(gridCenter + new Vector3(xOffsetTo, yOffsetTo, zOffsetTo));
                GL.End();
            }
        }
    }
}
