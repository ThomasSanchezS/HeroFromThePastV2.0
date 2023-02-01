using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiKO : MonoBehaviour
{

    public int bulletDamage = 2;
    private void Start()
    {
        Destroy(gameObject, 5f);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
        Debug.Log("hptaaa");
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(bulletDamage);
            }
        }
        Destroy(gameObject);
        }
}
