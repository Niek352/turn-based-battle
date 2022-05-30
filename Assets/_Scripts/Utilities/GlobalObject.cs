using UnityEngine;

namespace _Scripts.Utilities
{
    public class GlobalObject : MonoBehaviour
    {
        private static GlobalObject instance;
    
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }
    }
}