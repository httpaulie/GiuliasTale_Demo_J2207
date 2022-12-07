using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public Transform fogePonto;
    public Transform avancaPonto;
    Animator anim;
    public float radius;
    public float radius2;
    public float radius3;
    public float speed;
    public LayerMask playerLayer;
    GameObject Player;
    public static bool isAlive;
    private Health health;
    private bool onRadius;
    private bool onRadius2;
    public static bool onRange;
    private int tookDamage;
    public GameObject som;
    public GameObject som2;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
       if(DialogControl.dialogueTrue == false)
       {
        Interact();
        if(onRange)
        {
            if(onRadius)
            {
                transform.position = Vector2.MoveTowards(transform.position, fogePonto.transform.position, speed*Time.deltaTime);
            }
            if(onRadius2 == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, avancaPonto.transform.position, speed*Time.deltaTime);
            }
        }
        anim.SetBool("IsMoving", onRadius == true || onRadius2 == false);
        if(tookDamage >= 3)
        {
            Destroy(gameObject);
            isAlive = false;
        }
       } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bala"))
        {
            ++tookDamage;
            Instantiate(som2, transform.position, transform.rotation);
        }

        if(other.CompareTag("Player"))
        {
            --health.health;
            Instantiate(som, transform.position, transform.rotation);
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
        Collider2D hit3 = Physics2D.OverlapCircle(transform.position, radius3, playerLayer);

        if(hit3 != null)
        {
            onRange = true;
        }
        else
        {
            onRange = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius2);
        Gizmos.DrawWireSphere(transform.position, radius3);
    }
}
