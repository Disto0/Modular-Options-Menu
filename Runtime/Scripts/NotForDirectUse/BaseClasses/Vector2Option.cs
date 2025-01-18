using ModularOptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Vector2Option : OptionBase<Vector2, Vector2InputField>
{
    protected InputField inputX;
    protected InputField inputY;

    public override Vector2 Value 
    { 
        get => new Vector2(System.Convert.ToSingle(inputX.text), System.Convert.ToSingle(inputY.text)); 
        set
        {
            if (System.Convert.ToSingle(inputX.text) == value.x && System.Convert.ToSingle(inputY.text) == value.y)
                OnValueChange(value); //Ensure setting is applied when value is unchanged. OnValueChange event is only invoked when value is actually changed)
            else if(System.Convert.ToSingle(inputX.text) != value.x)
                inputX.text = value.ToString();
            else if (System.Convert.ToSingle(inputY.text) != value.y)
                inputY.text = value.ToString();
        }
    }

    /// <summary>
    /// Initializes values and subscribes listeners to events.
    /// </summary>
    protected virtual void Awake()
    {
        inputX = GetComponent<InputField>();
        inputY = GetComponent<InputField>();
        inputX.onValueChanged.AddListener((string _) => OnValueXChange(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
        inputY.onValueChanged.AddListener((string _) => OnValueYChange(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
        Value = OptionSaveSystem.LoadVector2(optionName, defaultSetting.value); //Saved value if there is one, else default. After subscribing so OnValueChange applies setting
    }

    protected void OnValueXChange(string _value)
    {
        float x = System.Convert.ToSingle(_value);
        float y = System.Convert.ToSingle(inputY.text);
        Vector2 value = new Vector2(x, y);
        OnValueChange(value);
    }

    protected void OnValueYChange(string _value)
    {
        float x = System.Convert.ToSingle(inputX.text);
        float y = System.Convert.ToSingle(_value);
        Vector2 value = new Vector2(x, y);
        OnValueChange(value);
    }
    protected void OnValueChange(Vector2 _value)
    {
        OptionSaveSystem.SaveVector2(optionName, _value);
        ApplySetting(_value);
        if (allowPresetCallback && preset != null)
            preset.SetCustom();
    }
}

[System.Serializable] public class Vector2InputField : UIDataType<Vector2> { }
/// <summary>
/// Editor dropdown for an int value, with dropdown options
/// fetched from the UI Dropdown on the same GameObject.
/// </summary>