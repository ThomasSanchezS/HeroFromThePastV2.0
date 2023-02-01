using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackHako : MonoBehaviour
{
    public Animator animate;
    public Transform AtackPoint;
    public float AtackRange = 0.5f;
    public LayerMask layerMask;
    public int damage = 5;
    private SoundManager soundManager;
    

    void Start(){
        animate = GetComponent<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            atack();
            soundManager.SeleccionAudio(1, 0.5f);
        }
    }
    void atack(){
        animate.SetTrigger("Atack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtackPoint.position, AtackRange, layerMask);
        foreach (Collider2D enemy in hitEnemies){
            EnemyHealth enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
        }
    }

