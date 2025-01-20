#if (UNITY_RENDER_PIPELINE_UNIVERSAL || UNITY_RENDER_PIPELINE_HIGH_DEFINITION)
using UnityEngine;
#if UNITY_RENDER_PIPELINE_UNIVERSAL
using UnityEngine.Rendering.Universal;
#elif UNITY_RENDER_PIPELINE_HIGH_DEFINITION
using UnityEngine.Rendering.HighDefinition;
#endif
namespace ModularOptions {
	[AddComponentMenu("Modular Options/Display/PostProcessing/Film Grain Slider")]
	public sealed class FilmGrainSlider : PostProcessingSlider<FilmGrain> {
		
		[Tooltip("Slider value is multiplied by this for final intensity value. Default 0.01 is for use with 0 to 100% slider.")]
		public float intensityFactor = 0.01f;

		protected override void ApplySetting(float _value){
			if (_value <= slider.minValue){
				setting.active = false;
			} else {
				setting.active = true;
				setting.intensity.value = _value * intensityFactor;
			}
		}
	}
}
#endif
