using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsData
{
    public float levelValue;
    public float strengthValue;
    public float attackValue;

    public StatsData()
    {
        GameObject statsUI = GameObject.Find("Stats UI");
        StatsUI statsScript = statsUI.GetComponent<StatsUI>();

        if(statsUI != null && statsScript != null)
        {
            Debug.Log("StatsData: Przypisano statystyki");

            levelValue = statsScript.levelValue;
            strengthValue = statsScript.strengthValue;
            attackValue = statsScript.attackValue;
            Debug.Log("StatsData: statystyki: " + levelValue + "\n" + strengthValue + "   " + attackValue);
        }
        else if(statsUI == null || statsScript == null)
            Debug.Log("StatsData: Nie przypisano statystyk");

        
        


       
    }
}
