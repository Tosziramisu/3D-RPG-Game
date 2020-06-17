using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;// { get; private set; }

    public Stat damage;
    public Stat armor;

    bool isFighting = false;
    int count = 0;
    int countLimit = 10;

    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    private float nextActionTimeBefore = 0.0f;
    public float periodBefore = 1.0f;

    public event System.Action<int ,int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        
        
        
        if(Time.time > nextActionTimeBefore && count < countLimit && isFighting)
        {
            nextActionTimeBefore += periodBefore;

            count++;
            Debug.Log("count = "+count);
        }

        if(count == countLimit)
        {
            isFighting = false;
            count++;
            nextActionTime = Time.time;
        }
            

        if(count > countLimit && !isFighting)
        {
            //isFighting = false;
            //if(!isFighting)
            //{
                if(OnHealthChanged != null)
                {
                    if(currentHealth < maxHealth)
                    {
                        if(Time.time > nextActionTime)
                        {
                            nextActionTime += period;
                            
                            currentHealth+=5;
                            if(currentHealth > maxHealth)
                            {
                                count = 0;
                                currentHealth = maxHealth;
                            }
                                

                            OnHealthChanged(maxHealth, currentHealth);
                        }
                        
                    }
                            
                }
            //}
        }
        
    }
    /*
    void Counter()
    {
        if(isFighting && count < 5)
        {
            count++;
            Debug.Log("count wynosi = "+count);

        }
        if(count == 5)
        {
            isFighting = false;
            return;
        }
    }
    */
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die(); 
        }

        if(transform.name == "Player")
        {
            count = 0;
            isFighting = true;
            nextActionTimeBefore = Time.time;
        }
        
        
        //InvokeRepeating("Counter", 1.0f, 1.0f);
    }
    
    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }

}
