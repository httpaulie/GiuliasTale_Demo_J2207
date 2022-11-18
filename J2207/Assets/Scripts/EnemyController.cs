using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    private bool isAlive;

    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;     
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive){
            if(player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bala"))
        {
            Destroy(gameObject, 1f);
            isAlive = false;
        }

        if(collision.CompareTag("Player"))
        {
            --health.health;
        }
    }
}
