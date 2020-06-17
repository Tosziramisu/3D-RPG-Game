using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{ 
    public GameObject menuUI;

    public Button startGameButton;
    public Button exitGameButton;
    public Button exitToMenuButton;
    public Button saveGameButton;
    public Button loadGameButton;

    Menu menu;
    //PlayerController player2;

    public GameObject player;

    void Start()
    {
        menu = Menu.instance;
        //player2 = GetComponent<PlayerController>();
        
        if( startGameButton != null)
        {
            startGameButton.onClick.AddListener(StartNewGame);
        }

        if( exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(QuitGame);
        }

        if( exitToMenuButton != null)
        {
            exitToMenuButton.onClick.AddListener(BackToMainMenu);
        }

        if( saveGameButton != null)
        {
            saveGameButton.onClick.AddListener(SavePlayer);
        }

        if( loadGameButton != null)
        {
            loadGameButton.onClick.AddListener(LoadPlayer);
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Menu")) 
        {
            CloseMenuUI();
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
        Debug.Log("MenuUI: Przycisk zapisu gry wykonał operację");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        GameObject statsUI = GameObject.Find("Stats UI");
        StatsUI statsScript = statsUI.GetComponent<StatsUI>();

        float levelValue = data.stats.levelValue;
        float strengthValue = data.stats.strengthValue;
        float attackValue = data.stats.attackValue;

        if(player != null && statsUI != null && statsScript != null)
        {
            player.transform.position = position;

            statsScript.levelValue = levelValue;
            statsScript.strengthValue = strengthValue;
            statsScript.attackValue = attackValue;

            statsScript.level.text = "Level " + levelValue.ToString();
            statsScript.strength.text = "Strength " + strengthValue.ToString();
            statsScript.attack.text = "Attack " + attackValue.ToString();
    
            Debug.Log("MenuUI: Przycisk wczytu gry wykonał operację");
        }
        else if(player == null && statsUI == null || statsScript == null)
            Debug.Log("MenuUI: Przycisk wczytu gry nie wykonał operacji");

    }
    
    void CloseMenuUI()
    { 
        bool isOpened = !menuUI.activeSelf;
        if(isOpened == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
      
        menuUI.SetActive(isOpened);
        //Debug.Log(isOpened);
        
    }
    
    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Time.timeScale = 1;
    }
}
