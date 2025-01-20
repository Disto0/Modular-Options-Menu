using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModularOptions
{
    [AddComponentMenu("Modular Options/Misc/Scene/AutoLoadSceneOption")]
    public class AutoLoadSceneOption : ToggleOption
    {
        public AutoLoadScene autoloader;
        protected override void ApplySetting(bool _value)
        {
            if(autoloader != null)
                autoloader.isEnabled = _value;
        }
    }
}
