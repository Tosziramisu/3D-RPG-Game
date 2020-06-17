using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    #region Singleton

    public static Stats instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Stats!");
            return;
        }

        instance = this;
    }
    #endregion

}
