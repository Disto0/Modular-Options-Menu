using System;
using UnityEngine;

namespace ModularOptions {
	/// <summary>
	/// Little utility script for disabling Options Menu in common Unity callback types.
	/// </summary>
	[AddComponentMenu("Modular Options/Misc/Disable On Callback")]
	public class DisableOnCallback : MonoBehaviour {

		// TODO Bitwise check with mask for multiples values support

		public UnityBehaviourCallbackType validCallbacks;
		void Awake()
		{
			if (validCallbacks == UnityBehaviourCallbackType.Awake)
				gameObject.SetActive(false);
		}

		void Start(){
			if(validCallbacks == UnityBehaviourCallbackType.Start)
				gameObject.SetActive(false);
		}

		void OnEnable()
		{
			if (validCallbacks == UnityBehaviourCallbackType.OnEnable)
				gameObject.SetActive(false);
		}
	}
}
