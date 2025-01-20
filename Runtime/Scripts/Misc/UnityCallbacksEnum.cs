using System;

[Flags]
public enum UnityBehaviourCallbackType
{
	Awake = 1,
	Start = 2,
	OnEnable = 4,
	OnDisable = 8,
	OnDestroy = 16
}

[Flags]
public enum UnityGameLoopCallbackType
{
	FixedUpdate = 1,
	Update = 2,
	LateUpdate = 4,
	OnGUI = 8
}

[Flags]
public enum UnityPhysicsCallbackType
{
	OnTriggerEnter = 1,
	OnTriggerEnter2D = 2,
	OnTriggerStay = 4,
	OnTriggerStay2D = 8,
	OnTriggerExit = 16,
	OnTriggerExit2D = 32,
	OnCollisionEnter = 64,
	OnCollisionEnter2D = 128,
	OnCollisionStay = 256,
	OnCollisionStay2D = 512,
	OnCollisionExit = 1024,
	OnCollisionExit2D = 2048,
	OnParticlesCollision = 4096
}

[Flags]
public enum UnityGameEventCallbackType
{
	OnApplicationFocus = 1,
	OnApplicationPause = 2,
	OnApplicationQuit = 4
}

[Flags]
public enum UnityEditorCallbackType
{
	OnDrawGizmos = 1,
	OnDrawGizmosSelected = 2,
	OnValidate = 4,
	Reset = 8
}
