using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModularOptions
{
    [AddComponentMenu("Modular Options/Misc/Scene/Menu Autoload Scene")]

    public class AutoLoadScene : MonoBehaviour
    {
        public bool isEnabled;
        [SceneRef] public string scene;

        private void Awake()
        {
            if (isEnabled)
                SceneManager.LoadScene(scene);
        }

    }
}
