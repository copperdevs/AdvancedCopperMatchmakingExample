using UnityEngine;

namespace CopperStudios.Tools
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null) 
                    return instance;
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                    instance = new GameObject(typeof(T).ToString()).AddComponent<T>();

                return instance;
            }
        }
    }
}