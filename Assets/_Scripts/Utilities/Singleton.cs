using UnityEngine;

namespace _Scripts.Utilities
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance) 
                    return instance;
                
                instance = FindObjectOfType<T>();
                if (!instance)
                {
                    Debug.LogError($"Singleton of type {typeof(T)} not contains in scene");
                    return null;
                }

                instance.AwakeSingleton();

                return instance;
            }
        }

        public static bool InstanceIsNotNull 
            => instance;

        private void Awake()
        {
            if (!instance)
            {
                instance = GetComponent<T>();
                AwakeSingleton();
            }
            else if (instance != this && !instance.GetComponentInParent<GlobalObject>())
                Debug.LogError($"Dublicated singleton instance {nameof(T)}", this);
        }  

        /// <summary>
        /// Aka default <see cref="Awake"/>
        /// </summary>
        protected virtual void AwakeSingleton() { }
    }
}