using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CopperStudios.Tools
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string targetScene;
        [SerializeField] private float delay;


        private void Start()
        {
            Invoke(nameof(LoadScene), delay);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}