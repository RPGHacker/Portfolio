using UnityEngine;
using System.Collections;

public enum CameraViewPlane
{
    XYPlane,
    XZPlane,
    YZPlane
}

public class CameraBase : MonoBehaviour
{
    public CameraViewPlane viewPlane = CameraViewPlane.XYPlane;

    public virtual Vector3 GetWorldSpawnPosition()
    {
        return Vector3.zero;
    }
}
