using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void TakeHealth(int moreHealth)
    {
        if(currentHealth + moreHealth <= maxHealth){
          currentHealth += moreHealth;
        }else if(currentHealth + moreHealth > maxHealth ){
            currentHealth = maxHealth;
        }
    }
}
