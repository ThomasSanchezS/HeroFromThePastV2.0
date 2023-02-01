using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject DeadEfect;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0){
            GameObject efect = Instantiate(DeadEfect, transform.position, Quaternion.identity);
            soundManager.SeleccionAudio(0, 0.5f);
            Destroy(efect, 2f);
            Destroy(gameObject);
        }
    }
}
