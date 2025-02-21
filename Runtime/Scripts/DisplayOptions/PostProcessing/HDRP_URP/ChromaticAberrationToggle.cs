#if (USE_URP || USE_HDRP)
using UnityEngine;
#if USE_URP
using UnityEngine.Rendering.Universal;
#elif USE_HDRP
using UnityEngine.Rendering.HighDefinition;
#endif
namespace ModularOptions {
	[AddComponentMenu("Modular Options/Display/PostProcessing/Chromatic Aberration Toggle")]
	public sealed class ChromaticAberrationToggle : PostProcessingToggle<ChromaticAberration> {}
}
#endif
