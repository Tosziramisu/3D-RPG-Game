using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUI;
    public GameObject player;

    public Button levelUpButton;
    public Button stengthUpButton;
    public Button attackUpButton;

    public Text level;
    public Text strength;

    public Text attack;
    public Text defense;
    public Text maxHealth;
    public Text currentHealth;

    public float levelValue;
    public float strengthValue;
    
    public float attackValue;
    public float defenseValue;
    public float maxHealthValue;
    public float currentHealthValue;

    Stats stats;
    //PlayerController player2;

    //public GameObject player;

    void Start()
    {
        level.text = "Level " + levelValue.ToString(); 
        strength.text = "Strength " + strengthValue.ToString();
        attack.text = "Attack " + attackValue.ToString();

        stats = Stats.instance;
        //player2 = GetComponent<PlayerController>();
        
        if( levelUpButton != null)
        {
            levelUpButton.onClick.AddListener(addLevel);
        }

        if( stengthUpButton != null)
        {
            stengthUpButton.onClick.AddListener(addStrenght);
        }

        if( attackUpButton != null)
        {
            attackUpButton.onClick.AddListener(addAttack);
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Stats")) 
        {
            attackValue = player.GetComponent<PlayerStats>().SetDamage();
            defenseValue = player.GetComponent<PlayerStats>().SetDefense();
            maxHealthValue = player.GetComponent<PlayerStats>().SetMaxHealth();
            currentHealthValue = player.GetComponent<PlayerStats>().SetCurrentHealth();

             
            attack.text = "Attack     " + attackValue.ToString();
            defense.text = "Defense     " + defenseValue.ToString();
            maxHealth.text = "Max Health     " + maxHealthValue.ToString();
            currentHealth.text = "Current Health     " + currentHealthValue.ToString();
            CloseStatsUI();
        }
    }

    void CloseStatsUI()
    { 
        bool isOpened = !statsUI.activeSelf;
        if(isOpened == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
      
        statsUI.SetActive(isOpened);
        //Debug.Log(isOpened);
        
    }

    void addLevel()
    {
        levelValue++;
        level.text = "Level " + levelValue.ToString();

        strengthValue+=2;
        strength.text = "Strength " + strengthValue.ToString();

        attackValue+=4;
        attack.text = "Attack " + attackValue.ToString();
    }

    void addStrenght()
    {
        strengthValue++;
        strength.text = "Strength " + strengthValue.ToString();
    }

    void addAttack()
    {
        attackValue++;
        attack.text = "Attack " + attackValue.ToString();
    }
}
