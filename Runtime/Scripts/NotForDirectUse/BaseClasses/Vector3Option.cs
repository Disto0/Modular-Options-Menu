using ModularOptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Vector3Option : OptionBase<Vector3, Vector3InputField>
{
    [SerializeField]
    protected TMPro.TMP_InputField inputX;
    [SerializeField]
    protected TMPro.TMP_InputField inputY;
    [SerializeField]
    protected TMPro.TMP_InputField inputZ;

    public override Vector3 Value 
    { 
        get => new Vector3(System.Convert.ToSingle(inputX.text), System.Convert.ToSingle(inputY.text), System.Convert.ToSingle(inputZ.text)); 
        set
        {
            if (System.Convert.ToSingle(inputX.text) == value.x && System.Convert.ToSingle(inputY.text) == value.y && System.Convert.ToSingle(inputZ.text) == value.z)
                OnValueChange(value); //Ensure setting is applied when value is unchanged. OnValueChange event is only invoked when value is actually changed)
            else if(System.Convert.ToSingle(inputX.text) != value.x)
                inputX.text = value.x.ToString();
            else if (System.Convert.ToSingle(inputY.text) != value.y)
                inputY.text = value.y.ToString();
            else if (System.Convert.ToSingle(inputZ.text) != value.z)
                inputZ.text = value.z.ToString();
        }
    }

    /// <summary>
    /// Initializes values and subscribes listeners to events.
    /// </summary>
    protected virtual void Awake()
    {
        inputX.onValueChanged.AddListener((string _) => OnValueXChange(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
        inputY.onValueChanged.AddListener((string _) => OnValueYChange(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
        inputZ.onValueChanged.AddListener((string _) => OnValueZChange(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
        Value = OptionSaveSystem.LoadVector3(optionName, defaultSetting.value); //Saved value if there is one, else default. After subscribing so OnValueChange applies setting
    }

    protected void OnValueXChange(string _value)
    {
        float x = System.Convert.ToSingle(_value);
        float y = System.Convert.ToSingle(inputY.text);
        float z = System.Convert.ToSingle(inputZ.text);
        Vector3 value = new Vector3(x, y);
        OnValueChange(value);
    }

    protected void OnValueYChange(string _value)
    {
        float x = System.Convert.ToSingle(inputX.text);
        float y = System.Convert.ToSingle(_value);
        float z = System.Convert.ToSingle(inputZ.text);
        Vector3 value = new Vector3(x, y);
        OnValueChange(value);
    }
    protected void OnValueZChange(string _value)
    {
        float x = System.Convert.ToSingle(inputX.text);
        float y = System.Convert.ToSingle(inputZ.text);
        float z = System.Convert.ToSingle(_value);
        Vector3 value = new Vector3(x, y, z);
        OnValueChange(value);
    }
    protected void OnValueChange(Vector3 _value)
    {
        OptionSaveSystem.SaveVector3(optionName, _value);
        ApplySetting(_value);
        if (allowPresetCallback && preset != null)
            preset.SetCustom();
    }
}

[System.Serializable] public class Vector3InputField : UIDataType<Vector3> { }
/// <summary>
/// Editor dropdown for an int value, with dropdown options
/// fetched from the UI Dropdown on the same GameObject.
/// </summary>