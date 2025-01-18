using UnityEngine;

namespace ModularOptions {
	/// <summary>
	/// Base-class for option controls.
	/// UI element base classes inherit from this with their data type as type parameter.
	/// </summary>
	public abstract class OptionBase<T, U> : MonoBehaviour
		where T : struct
		where U : UIDataType<T> {

		[Tooltip("Key for saving & loading, with other possible re-use.")]
		public string optionName;

		public U defaultSetting; //A simple value-type, wrapped in a Serializable class to use PropertyDrawers

		public abstract T Value { get; set; }

		[HideInInspector] public OptionPreset preset; //Used for preset callbacks
		protected bool allowPresetCallback = true;
		/// <summary>
		/// Method wrapper for Value setter to prevent callbacks when changed through preset.
		/// </summary>
		public void ApplyPreset(T _value){
			allowPresetCallback = false;
			Value = _value;
			allowPresetCallback = true;
		}

		/// <summary>
		/// Override with the code relevant to applying the setting you want changed.
		/// Abstract rather than virtual because it has no base functionality and is core to the class.
		/// </summary>
		protected abstract void ApplySetting(T _value);

#if UNITY_EDITOR
		/// <summary>
		/// Automatic default optionName assignment.
		/// NOTE: Requires assignment in editor to work with multiple instances.
		/// VolumeSliders for example need separate names per slider or they'll over-write each other.
		/// </summary>
		protected virtual void Reset(){
			optionName = GetType().ToString();
		}
#endif
	}

	/// <summary>
	/// Wrapper class for UI data values.
	/// Used so the data can be drawn in a user-friendly way with PropertyDrawers.
	/// </summary>
	[System.Serializable]
	public class UIDataType<T> where T : struct {
		[Tooltip("Setting used if no saved setting exists. Can also be used externally to restore defaults.")]
		[SerializeField] public T value;
	}
	//Wrappers because Unity can't serialize generic classes
	/// <summary>
	/// Editor slider for a float value, with min/max/wholeNumbers parameters
	/// fetched from the UI Slider on the same GameObject.
	/// </summary>
	[System.Serializable] public class FloatSlider : UIDataType<float> {}
	/// <summary>
	/// Editor dropdown for an int value, with dropdown options
	/// fetched from the UI Dropdown on the same GameObject.
	/// </summary>
	[System.Serializable] public class IntDropdown : UIDataType<int> {}
	/// <summary>
	/// Wrapper class for a bool. Does nothing, but is required by the framework.
	/// </summary>
	[System.Serializable] public class BoolToggle : UIDataType<bool> {}

	/// <summary>
	/// Acts like a wrapper for the SaveSystem to de-couple references in other parts of the system.
	/// I.e: if you want to change save system it can be swapped right here.
	/// </summary>
	public static class OptionSaveSystem {
		
		public static void SaveFloat(string _key, float _value){
			PlayerPrefs.SetFloat(_key, _value);
		}
		public static void SaveInt(string _key, int _value){
			PlayerPrefs.SetInt(_key, _value);
		}
		public static void SaveBool(string _key, bool _value){
			PlayerPrefs.SetInt(_key, _value ? 1 : 0); //Convert bool to int (1=true, 0=false)
		}

		public static float LoadFloat(string _key, float _defaultValue){
			return PlayerPrefs.GetFloat(_key, _defaultValue);
		}
		public static int LoadInt(string _key, int _defaultValue){
			return PlayerPrefs.GetInt(_key, _defaultValue);
		}
		public static bool LoadBool(string _key, bool _defaultValue){
			if (PlayerPrefs.HasKey(_key))
				return PlayerPrefs.GetInt(_key) > 0; //Converts int to bool (1=true, 0=false)
			else
				return _defaultValue;
		}


		public static void SaveVector2(string _key, Vector2 _value)
		{
			PlayerPrefs.SetFloat(_key + "_x", _value.x);
			PlayerPrefs.SetFloat(_key + "_x", _value.y);
		}

		public static Vector2 LoadVector2(string _key, Vector2 _defaultValue)
		{
			float x = PlayerPrefs.GetFloat(_key + "_x", _defaultValue.x);
			float y = PlayerPrefs.GetFloat(_key + "_y", _defaultValue.y);
			return new Vector2(x, y);
		}

		public static void SaveVector3(string _key, Vector3 _value)
		{
			PlayerPrefs.SetFloat(_key + "_x", _value.x);
			PlayerPrefs.SetFloat(_key + "_y", _value.y);
			PlayerPrefs.SetFloat(_key + "_z", _value.z);
		}

		public static Vector3 LoadVector3(string _key, Vector3 _defaultValue)
		{
			float x = PlayerPrefs.GetFloat(_key + "_x", _defaultValue.x);
			float y = PlayerPrefs.GetFloat(_key + "_y", _defaultValue.y);
			float z = PlayerPrefs.GetFloat(_key + "_z", _defaultValue.z);
			return new Vector3(x, y, z);
		}

		public static void SaveVector4(string _key, Vector4 _value)
		{
			PlayerPrefs.SetFloat(_key + "_x", _value.x);
			PlayerPrefs.SetFloat(_key + "_y", _value.y);
			PlayerPrefs.SetFloat(_key + "_z", _value.z);
			PlayerPrefs.SetFloat(_key + "_w", _value.w);
		}

		public static Vector4 LoadVector4(string _key, Vector4 _defaultValue)
		{
			float x = PlayerPrefs.GetFloat(_key + "_x", _defaultValue.x);
			float y = PlayerPrefs.GetFloat(_key + "_y", _defaultValue.y);
			float z = PlayerPrefs.GetFloat(_key + "_z", _defaultValue.z);
			float w = PlayerPrefs.GetFloat(_key + "_w", _defaultValue.w);
			return new Vector4(x, y, z, w);
		}

		public static void SaveQuaternion(string _key, Quaternion _value)
		{
			PlayerPrefs.SetFloat(_key + "_x", _value.x);
			PlayerPrefs.SetFloat(_key + "_y", _value.y);
			PlayerPrefs.SetFloat(_key + "_z", _value.z);
			PlayerPrefs.SetFloat(_key + "_w", _value.w);
		}

		public static Quaternion LoadQuaternion(string _key, Quaternion _defaultValue)
		{
			float x = PlayerPrefs.GetFloat(_key + "_x", _defaultValue.x);
			float y = PlayerPrefs.GetFloat(_key + "_y", _defaultValue.y);
			float z = PlayerPrefs.GetFloat(_key + "_z", _defaultValue.z);
			float w = PlayerPrefs.GetFloat(_key + "_w", _defaultValue.w);
			return new Quaternion(x, y, z, w);
		}

		/// <summary>
		/// Changed settings are kept in memory even without calling PlayerPrefs.Save(), but not saved to disk until
		/// PlayerPrefs.Save() is called or the application quits. Saving avoids loss of data in the case of a crash.
		/// </summary>
		public static void SaveToDisk(){
			PlayerPrefs.Save();
		}
	}
}
