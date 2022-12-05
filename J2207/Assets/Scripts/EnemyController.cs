using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    Animator anim;
    private bool isAlive;
    public LayerMask playerLayer;
    public float radius;
    public float radius2;
    public bool onRadius;
    public bool onRadius2;
    private int tookDamage = 0;
    private Health health;
    private DialogControl dialog;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;     
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    { if(DialogControl.dialogueTrue == false)
      {
        Interact();
        if(tookDamage >=7)
        {
            isAlive = false;
            Destroy(gameObject);
        }
        if(isAlive)
        {
            if(player != null && onRadius2)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
            }
        }
      } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bala"))
        {
            ++tookDamage;
        }

        if(collision.CompareTag("Player") && Player.Levou == false)
        {
            --health.health;
            Player.Levou = true;
        }
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

        Collider2D hit2 = Physics2D.OverlapCircle(transform.position, radius2, playerLayer);

        if(hit2 != null)
        {
            onRadius2 = true;
        }
        else
        {
            onRadius2 = false;
        }

        anim.SetBool("IsPunching", onRadius == true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
