using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVision : MonoBehaviour
{
    [Range(0f,360f)]
    public float anguloVision = 90f;
    public float distanciaVision = 4f;
    public float distanciaDeteccion = 2f;
    public GameObject[] playerCharacters;

    [SerializeField] LayerMask layerMask;
    Vector2 lookDir;
    private float width;


    private void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x/3;
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
    }

    private Vector3 PointForAngle(float angulo)
    {

        Vector2 ret = new Vector2(Mathf.Cos((angulo + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad) * distanciaVision + transform.position.x,
            Mathf.Sin((angulo + transform.rotation.eulerAngles.z) * Mathf.Deg2Rad) * distanciaVision + transform.position.y) ;

        return ret;
    }
    private void FixedUpdate()
    {

        foreach (GameObject jugadorpj in playerCharacters)
        {
            Vector2 jugadorpjpositon = jugadorpj.transform.position;
            Vector2 dirtopj = (jugadorpjpositon - (Vector2)transform.position).normalized;
            float angle = Vector3.Angle(transform.right, dirtopj);
            if (angle <= anguloVision/2)
            {
                 if (Vector2.Distance(jugadorpjpositon, transform.position) <= distanciaVision)
                {
                    
                   RaycastHit2D viewHitInfo = Physics2D.Raycast(GetComponent<TurretAttack>().firepoint.position, dirtopj, distanciaVision, layerMask);
                    if (viewHitInfo.collider != null) {
                        if(viewHitInfo.collider.gameObject.GetComponent<MovimientoJugador>() != null)
                        {       
                            Debug.Log("Te veo sapa hpta");
                            GetComponent<TurretAttack>().ShootAt(jugadorpj.transform);
                        }
                    }
                }
            }
        }
    }
    
public void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        headPos.y = headPos.y + 0.8f;
        if (anguloVision <= 0) return;
        float AnguloVisionMitad = anguloVision * 0.5f;

        Vector3 p1, p2;
        p1 = PointForAngle(AnguloVisionMitad);
        p2 = PointForAngle(-AnguloVisionMitad);

        Gizmos.DrawLine(headPos, p1);
        Gizmos.DrawLine(headPos, p2);
        Gizmos.DrawWireSphere(headPos, distanciaVision);
    }
}
