using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBullet : MonoBehaviour
{ 
    [SerializeField] float speed;
    private Health health;
    public GameObject som;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if(other.CompareTag("Player") && Player.Levou == false)
        {
            --health.health;
            Player.Levou = true;
            Instantiate(som, transform.position, transform.rotation);
        }
    }
}
