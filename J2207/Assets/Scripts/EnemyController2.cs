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
    public float speed;
    public LayerMask playerLayer;
    GameObject Player;
    public static bool isAlive;
    private Health health;
    private bool onRadius;
    private bool onRadius2;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        Interact();
        if(onRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, fogePonto.transform.position, speed*Time.deltaTime);
        }
        if(onRadius2 == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, avancaPonto.transform.position, speed*Time.deltaTime);
        }
        anim.SetBool("IsMoving", onRadius == true || onRadius2 == false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bala"))
        {
            Destroy(gameObject);
            isAlive = false;
        }

        if(other.CompareTag("Player"))
        {
            --health.health;
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius2);
    }
}
