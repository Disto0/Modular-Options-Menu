using ModularOptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EditableSliderOption : SliderOption
{
#if UNITY_EDITOR
	/// <summary>
	/// Add a display script by default, because it's good form to show the user the value of a slider.
	/// Can easily be removed if undesired; it's optional, but recommended.
	/// </summary>
	protected override void Reset()
	{
		if (GetComponent<DisplaySliderWithEditTextValue>() == null)
			UnityEditor.Undo.AddComponent<DisplaySliderWithEditTextValue>(gameObject);
		base.Reset();
	}
#endif
}
