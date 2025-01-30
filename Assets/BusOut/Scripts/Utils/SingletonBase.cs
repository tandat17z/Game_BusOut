using UnityEngine;

namespace GameTandat17z
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        /// <summary>
        /// Determines whether the singleton should persist across scene loads.
        /// </summary>
        protected virtual bool PersistAcrossScenes => false;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;

                // Optionally persist the singleton across scene loads
                if (PersistAcrossScenes)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Debug.LogWarning($"[SingletonBase] More than one instance of {typeof(T)} detected. Destroying the new instance.");
                Destroy(gameObject);
            }
        }

        protected virtual void OnApplicationPause(bool pauseStatus)
        {
            /// Override this method to handle application pause event
        }

        protected virtual void OnApplicationQuit()
        {
            /// Override this method to handle application quit event
        }

        protected virtual void OnDestroy()
        {
            /// Override this method to handle object destruction
        }
    }

}