using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    Transform siguientePosicion;
    float distanciaDeCambio = 1.0f;
    int indiceWaypoints = 0;
    public float speed;
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
        siguientePosicion = waypoints[0];
        enemy = GetComponent<Rigidbody2D>();
        enemigoVision = GetComponent<EnemyVision>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lookDir = (Vector2)siguientePosicion.position - enemy.position;
        
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        enemy.rotation = angle;
        if(lookDir.x<0){
            if(transform.localScale.y > 0){
               transform.localScale= new Vector3(1f * transform.localScale.x,-1f *transform.localScale.y,1f *transform.localScale.z);
        }
    }
        if(lookDir.x>0){
            if(transform.localScale.y < 0){
               transform.localScale= new Vector3(1f * transform.localScale.x,-1f *transform.localScale.y,1f *transform.localScale.z);
        }
        }
        transform.position = Vector3.MoveTowards(transform.position, siguientePosicion.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, siguientePosicion.position) < distanciaDeCambio)
        {
            indiceWaypoints++;
            if (indiceWaypoints >= waypoints.Length)
            {
                indiceWaypoints = 0;
            }
            siguientePosicion = waypoints[indiceWaypoints];
        }
    }
public void ShootAt(Transform objetivo)
    {
        Vector2 lookDir = (Vector2) objetivo.transform.position - enemy.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        enemy.rotation = angle;
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
