#if (UNITY_RENDER_PIPELINE_UNIVERSAL || UNITY_RENDER_PIPELINE_HIGH_DEFINITION)
using UnityEngine;
#if UNITY_RENDER_PIPELINE_UNIVERSAL
using UnityEngine.Rendering.Universal;
#elif UNITY_RENDER_PIPELINE_HIGH_DEFINITION
using UnityEngine.Rendering.HighDefinition;
#endif
namespace ModularOptions {
	[AddComponentMenu("Modular Options/Display/PostProcessing/Chromatic Aberration Toggle")]
	public sealed class ChromaticAberrationToggle : PostProcessingToggle<ChromaticAberration> {}
}
#endif
