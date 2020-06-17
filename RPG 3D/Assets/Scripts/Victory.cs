using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject enemies;
    public GameObject victorySpot;
    public GameObject enemiesKilledText;

    bool allKilled = false;

    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.T))
        {
             
        }
        */
        if(ifAllEnemiesKilled())
        {
            victorySpot.SetActive(!victorySpot.activeSelf);
            StartCoroutine(ShowMessage(5));
        }
    }

    IEnumerator ShowMessage (float delay) 
    {
        bool isOpened = !enemiesKilledText.activeSelf;
        enemiesKilledText.SetActive(isOpened);
        yield return new WaitForSeconds(delay);
        enemiesKilledText.SetActive(!isOpened);
    }

    bool ifAllEnemiesKilled()
    {
        if(allKilled)
            return false;
        int enemiesCount = enemies.transform.childCount;
        if(enemiesCount == 0)
        {
            allKilled = true;
            return true;
        }
            
        return false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "VictorySpot")
        {
            Debug.Log("You won!");

            VictoryScreen();
        }
    }

    void VictoryScreen()
    {
        bool isOpened = !victoryUI.activeSelf;

        if(isOpened == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    
        victoryUI.SetActive(isOpened);
    }
}
