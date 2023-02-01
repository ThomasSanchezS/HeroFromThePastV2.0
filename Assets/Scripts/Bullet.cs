using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 2;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Enemy")){
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hptaaa");
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(bulletDamage);
            }
        }
        Destroy(gameObject);
        }
     }
}
        
            
