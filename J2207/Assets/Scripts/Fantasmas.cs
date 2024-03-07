using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmas : MonoBehaviour
{
    public float speed;
    public float radius;
    public LayerMask playerLayer;
    public GameObject destino1;
    public GameObject destino2;
    bool onRadius;
    bool chegou;
    int tempo;
    SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Interact();
        if(onRadius == false)
        {
            tempo++;
            if(tempo <= 480)
            {
                transform.position = Vector2.MoveTowards(transform.position, destino2.transform.position, speed*Time.deltaTime);
                sprite.flipX = false;
            }
            if(tempo > 480)
            {
                transform.position = Vector2.MoveTowards(transform.position, destino1.transform.position, speed*Time.deltaTime);
                sprite.flipX = true;
            }
            if(tempo >= 960) tempo = 0;
        }
        Debug.Log(tempo);
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
