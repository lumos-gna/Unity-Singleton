using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new();

    public static T Instance 
    {
        get {
            if (_instance == null) 
            {
                lock (_lock) 
                {
                    var obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
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
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this) 
        {
            Destroy(gameObject);
        }
    }
}