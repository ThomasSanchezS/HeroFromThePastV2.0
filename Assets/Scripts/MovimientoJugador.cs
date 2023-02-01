using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D player;
    Vector2 movement;
    public float fuerzaSalto;
    private Animator animate;
    public BoxCollider2D collider;
    
    // Start is called before the first frame update

    bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + 0.1f);
        return raycastHit.collider!=null;
    }
    void Start()
    {
       collider = GetComponent<BoxCollider2D>();
       animate = GetComponent<Animator>();
       player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("space")){
            if(IsGrounded()){
            animate.SetTrigger("Jump");
            animate.SetBool("IsJumping", true);
            player.velocity = new Vector2(player.velocity.x, fuerzaSalto);
            //player.AddForce(new Vector2(0, fuerzaSalto),ForceMode2D.Impulse);
            }
        }
        animate.SetBool("IsJumping", !IsGrounded());
    }
    void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");
        
        if(Input.GetAxis("Horizontal")!= 0){
           movement.x = Input.GetAxis("Horizontal");
           //player.MovePosition(player.position + movement * speed * Time.fixedDeltaTime);
           //player.AddForce(new Vector2(speed * Time.fixedDeltaTime,0), ForceMode2D.Impulse);  
           player.velocity = new Vector2(dirX * speed, player.velocity.y );


           animate.SetBool("Run", true);
           if(Input.GetAxis("Horizontal")<0){
               if(player.transform.localScale.x>0){
               player.transform.localScale= new Vector3(-1f * player.transform.localScale.x,1f *player.transform.localScale.y,1f *player.transform.localScale.z);
               }
           }else if(Input.GetAxis("Horizontal")>0){
               if(player.transform.localScale.x<0){
               player.transform.localScale= new Vector3(-1f * player.transform.localScale.x,1f *player.transform.localScale.y,1f *player.transform.localScale.z);
               }
           }
        }
        else{
            animate.SetBool("Run", false);
        }
    }
}
