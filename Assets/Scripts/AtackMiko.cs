using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMiko : MonoBehaviour
{
    public Animator animate;
    public Transform AtackPoint;
    public LayerMask layerMask;
    public int damage = 5;
    public GameObject bulletPrefab;
    private SoundManager soundManager;
    public float bulletForce = 20f;
    public float Cd = 0;
    public float AttackRate = 0.2f;
    

    void Start(){
        animate = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            if(Cd <= 0){
                atack();
                Cd = AttackRate;
            soundManager.SeleccionAudio(1, 0.5f);
            }
        }
        if(Cd > 0){
            Cd = Cd - Time.deltaTime;
        }
            animate.SetBool("IsAttacking", Input.GetKey(KeyCode.J));
    }
    void atack(){
        float dirX = gameObject.transform.localScale.x;
        dirX = dirX / Mathf.Abs(dirX);
        animate.SetTrigger("Atack");
        GameObject bullet = Instantiate(bulletPrefab, AtackPoint.position, AtackPoint.rotation);
        bullet.GetComponent<BulletMiKO>().bulletDamage =  damage;
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.AddForce(AtackPoint.right * bulletForce * dirX, ForceMode2D.Impulse);
        bullet.transform.localScale= new Vector3(dirX * bullet.transform.localScale.x,1f *bullet.transform.localScale.y,1f *bullet.transform.localScale.z);
        }
        }

