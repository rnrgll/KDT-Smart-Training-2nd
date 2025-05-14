
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance==null)
                CreateInstace();
            return _instance;
        }
    }

    public static void CreateInstace()
    {
        _instance = FindObjectOfType<T>();
        if (_instance == null)
        {
            GameObject go = new GameObject(typeof(T).Name);
            _instance = go.AddComponent<T>();
        }
        DontDestroyOnLoad(_instance.gameObject);
        
    }

    public static void ReleaseInstance()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
            _instance = null;
        }
    }
}
