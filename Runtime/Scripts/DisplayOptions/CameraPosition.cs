using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Modular Options/Display/Camera/CameraPosition")]
public class CameraPosition : Vector3Option
{
    public Camera targetCamera;
    protected override void ApplySetting(Vector3 _value)
    {
        if(targetCamera != null)
            targetCamera.transform.localPosition = _value;
        else
            Debug.LogFormat("{0} not set. (This message must be logged only in menu scene)", targetCamera);
    }
}
