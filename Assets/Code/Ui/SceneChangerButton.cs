using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CopperMatchmaking.Example.Ui
{
    [RequireComponent(typeof(Button))]
    public class SceneChangerButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(ChangeScene);
        }

        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveListener(ChangeScene);
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}