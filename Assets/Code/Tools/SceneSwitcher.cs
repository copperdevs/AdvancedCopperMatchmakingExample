using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CopperStudios.Tools
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string targetScene;
        [SerializeField] private float delay;
        [SerializeField] private LoadSceneMode loadMode = LoadSceneMode.Single;


        private void Start()
        {
            Invoke(nameof(LoadScene), delay);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(targetScene, loadMode);
        }
    }
}