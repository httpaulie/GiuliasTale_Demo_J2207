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
    public bool onRadius;
    private int tookDamage = 0;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;     
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            if(player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
            }
        }
        Interact();
        if(tookDamage >=3)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bala"))
        {
            ++tookDamage;
        }

        if(collision.CompareTag("Player"))
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

        anim.SetBool("IsPunching", onRadius == true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
