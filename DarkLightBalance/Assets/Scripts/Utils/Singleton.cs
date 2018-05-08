#region Imports
using UnityEngine;
#endregion

/// <summary>
/// Singleton permettant de gérer l'instanciation ou la destruction UNIQUE d'une classe
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    #region Variables
    private static T _instance;

    private static object _lock = new object();

    private static bool applicationIsQuitting = false;
    #endregion

    #region Propriétés
    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] L'instance '" + typeof(T) +
                    "' à déjà été détruire à la fermeture de l'appli.");
               
                return null;
            }


            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Impossible d'instancier plus d'un singleton.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] Une instance du singleton " + typeof(T) +
                            " a été demandé '" + singleton +
                            "' à été créé au chargement.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] Utilisation d'une instance déjà créée: " +
                            _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }
    #endregion


    /// <summary>
    /// Récupération de l'état de l'application lors de la fermeture
    /// </summary>
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}