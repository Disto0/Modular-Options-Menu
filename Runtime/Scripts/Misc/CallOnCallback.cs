using System;
using UnityEngine;
using UnityEngine.Events;

namespace ModularOptions {
	/// <summary>
	/// Little utility script for calling an UnityEvent in common Unity callback types.
	/// </summary>
	[AddComponentMenu("Modular Options/Misc/Call On Callback")]
	public class CallOnCallback : MonoBehaviour {

		// TODO Bitwise check with mask for multiples values support

		public UnityBehaviourCallbackType validBehaviourCallbacks;
		public UnityEvent behaviourCallbacks;

		public UnityGameLoopCallbackType validGameLoopCallbacks;
		public UnityEvent gameLoopCallbacks;

		public UnityGameEventCallbackType validGameEventCallbacks;
		public UnityEvent gameEventCallbacks;

		public UnityEditorCallbackType validEditorCallbacks;
		public UnityEvent EditorCallbacks;

        #region Behaviour Callbacks
        void Awake()
		{
			if (validBehaviourCallbacks == UnityBehaviourCallbackType.Awake)
				behaviourCallbacks?.Invoke();
		}

		void Start(){
			if(validBehaviourCallbacks == UnityBehaviourCallbackType.Start)
				behaviourCallbacks?.Invoke();
		}

		void OnEnable()
		{
			if (validBehaviourCallbacks == UnityBehaviourCallbackType.OnEnable)
				behaviourCallbacks?.Invoke();
		}

		void OnDisable()
		{
			if (validBehaviourCallbacks == UnityBehaviourCallbackType.OnDisable)
				behaviourCallbacks?.Invoke();
		}

        private void OnDestroy()
        {
			if (validBehaviourCallbacks == UnityBehaviourCallbackType.OnDestroy)
				behaviourCallbacks?.Invoke();
		}
        #endregion

        #region GameLoop Callbacks
        private void FixedUpdate()
        {
			if (validGameLoopCallbacks == UnityGameLoopCallbackType.FixedUpdate)
				gameLoopCallbacks?.Invoke();
        }

		private void Update()
		{
			if (validGameLoopCallbacks == UnityGameLoopCallbackType.Update)
				gameLoopCallbacks?.Invoke();
		}

		private void LateUpdate()
		{
			if (validGameLoopCallbacks == UnityGameLoopCallbackType.LateUpdate)
				gameLoopCallbacks?.Invoke();
		}
        #endregion

        #region GameEvent Callbacks
        private void OnApplicationFocus(bool focus)
        {
			if (validGameEventCallbacks == UnityGameEventCallbackType.OnApplicationFocus)
				gameEventCallbacks?.Invoke();
        }

        private void OnApplicationPause(bool pause)
        {
			if (validGameEventCallbacks == UnityGameEventCallbackType.OnApplicationPause)
				gameEventCallbacks?.Invoke();
		}

        private void OnApplicationQuit()
        {
			if (validGameEventCallbacks == UnityGameEventCallbackType.OnApplicationQuit)
				gameEventCallbacks?.Invoke();
		}
        #endregion

#if UNITY_EDITOR
        #region Editor Callbacks
        private void OnDrawGizmos()
        {
			if (validEditorCallbacks == UnityEditorCallbackType.OnDrawGizmos)
				EditorCallbacks?.Invoke();
		}

        private void OnDrawGizmosSelected()
        {
			if (validEditorCallbacks == UnityEditorCallbackType.OnDrawGizmosSelected)
				EditorCallbacks?.Invoke();
		}
        private void OnValidate()
        {
			if (validEditorCallbacks == UnityEditorCallbackType.OnValidate)
				EditorCallbacks?.Invoke();
        }

        private void Reset()
        {
			if (validEditorCallbacks == UnityEditorCallbackType.Reset)
				EditorCallbacks?.Invoke();
		}
        #endregion
#endif
    }
}
