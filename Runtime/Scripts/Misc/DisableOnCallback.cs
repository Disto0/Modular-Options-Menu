using System;
using UnityEngine;

namespace ModularOptions {
	/// <summary>
	/// Little utility script for disabling Options Menu in common Unity callback types.
	/// </summary>
	[AddComponentMenu("Modular Options/Misc/Disable On Callback")]
	public class DisableOnCallback : MonoBehaviour {


		public UnityCallbackMessageType callbacks;
		void Awake()
		{
			if (callbacks == UnityCallbackMessageType.Awake)
				gameObject.SetActive(false);
		}

		void Start(){
			if(callbacks == UnityCallbackMessageType.Start)
				gameObject.SetActive(false);
		}

		void OnEnable()
		{
			if (callbacks == UnityCallbackMessageType.OnEnable)
				gameObject.SetActive(false);
		}
	}

	[Flags]
	public enum UnityCallbackMessageType
    {
		Awake = 1,
		Start = 2,
		OnEnable = 4
    }
}
