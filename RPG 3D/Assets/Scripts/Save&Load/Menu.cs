using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region Singleton

    public static Menu instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Menu!");
            return;
        }

        instance = this;
    }
    #endregion

}
