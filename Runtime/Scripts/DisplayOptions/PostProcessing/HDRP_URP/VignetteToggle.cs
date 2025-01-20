#if (UNITY_RENDER_PIPELINE_HIGH_DEFINITION || UNITY_RENDER_PIPELINE_HIGH_DEFINITION)
using UnityEngine;
#if UNITY_RENDER_PIPELINE_HIGH_DEFINITION
using UnityEngine.Rendering.Universal;
#elif UNITY_RENDER_PIPELINE_HIGH_DEFINITION
using UnityEngine.Rendering.HighDefinition;
#endif
namespace ModularOptions {
	[AddComponentMenu("Modular Options/Display/PostProcessing/Vignette Toggle")]
	public sealed class VignetteToggle : PostProcessingToggle<Vignette> {}
}
#endif
