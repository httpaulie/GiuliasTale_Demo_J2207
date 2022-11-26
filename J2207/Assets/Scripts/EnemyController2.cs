using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public Transform fogePonto;
    public float radius;
    public float speed;
    public LayerMask playerLayer;
    GameObject Player;
    public static bool isAlive;
    private Health health;
    private bool onRadius;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;
    }


    void Update()
    {
        Interact();
        if(onRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, fogePonto.transform.position, speed*Time.deltaTime);
        }
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
