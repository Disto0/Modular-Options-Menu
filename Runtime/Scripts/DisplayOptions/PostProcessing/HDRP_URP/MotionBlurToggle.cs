#if (UNITY_RENDER_PIPELINE_HIGH_DEFINITION || UNITY_RENDER_PIPELINE_HIGH_DEFINITION)
using UnityEngine;
#if UNITY_RENDER_PIPELINE_UNIVERSAL
using UnityEngine.Rendering.Universal;
#elif UNITY_RENDER_PIPELINE_HIGH_DEFINITION
using UnityEngine.Rendering.HighDefinition;
#endif
namespace ModularOptions {
	[AddComponentMenu("Modular Options/Display/PostProcessing/Motion Blur Toggle")]
	public sealed class MotionBlurToggle : PostProcessingToggle<MotionBlur> {}
}
#endif
