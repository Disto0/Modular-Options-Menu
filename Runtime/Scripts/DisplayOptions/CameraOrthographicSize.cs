using ModularOptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Orthographic Size slider for Unity camera. Requires an optionName that matches the exposed parameter.
/// </summary>
[AddComponentMenu("Modular Options/Display/Camera/Orthographic Size")]
public class CameraOrthographicSize : EditableSliderOption
{
    public Camera targetCamera;
    protected override void ApplySetting(float _value)
    {
        if (targetCamera != null)
            targetCamera.orthographicSize = _value;
        else
            Debug.LogFormat("{0} not set. (This message must be logged only in menu scene)", targetCamera);
    }
}
