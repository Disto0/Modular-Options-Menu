using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions {
	/// <summary>
	/// Updates a UI Text element to show the value of a UI Slider.
	/// Use ISliderDisplayFormatter interface for custom text formatting.
	/// </summary>
	[AddComponentMenu("Modular Options/Display Slider Value")]
	[RequireComponent(typeof(Slider))]
	public sealed class DisplaySliderWithEditTextValue : MonoBehaviour {

		[Tooltip("Text UI to use for displaying the slider value.")]
#if TMP_PRESENT
		public TMPro.TMP_InputField displayText;
#else
		public Text displayText;
#endif

		Slider slider;
		ISliderDisplayFormatter formattingOverride;

#if UNITY_EDITOR
		/// <summary>
		/// Automatically select first Text component found in children.
		/// The selected component can then be changed if it was the wrong one.
		/// </summary>
		void Reset(){
	#if TMP_PRESENT
			displayText = GetComponentInChildren<TMPro.TMP_InputField>();
	#else
			displayText = GetComponentInChildren<Text>();
	#endif
		}
#endif

		void Awake(){
			formattingOverride = GetComponent<ISliderDisplayFormatter>();
			slider = GetComponent<Slider>();
			SetDisplayText(slider.value);
			slider.onValueChanged.AddListener((float _) => SetDisplayText(_)); //UI classes use Unity events, requiring delegates (delegate() { OnValueChange(); }) or lambda expressions (() => OnValueChange()). Listeners are not persistent, so no need to unsub
		}

		void SetDisplayText(float _value){
			if (formattingOverride != null)
				displayText.text = formattingOverride.OverrideFormatting(_value);
			else
				displayText.text = _value.ToString();
		}

		public void SetSliderFromText(string value)
		{
			slider.value = System.Convert.ToSingle(value);
		}
	}
}
