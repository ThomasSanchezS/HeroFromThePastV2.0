using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Transform firepoint;
    public GameObject bulletPrefab;
    EnemyVision enemigoVision;
    public float bulletForce = 5f;
    public float attackRate = 15f;
    private float nextAttackTime = 0;
    GameObject EnemyGameObject;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemigoVision = GetComponent<EnemyVision>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        }
public void ShootAt(Transform objetivo)
    {
        Vector2 lookDir = (Vector2) objetivo.transform.position - enemy.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (Time.time >= nextAttackTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    void OnCollisionEnter(Collision col)
    {

    }
}
