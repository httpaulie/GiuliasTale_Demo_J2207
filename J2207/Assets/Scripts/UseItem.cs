using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private Transform player;
    private Health health;
    public GameObject effect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        Heal();
    }

    void Heal()
    {
        if(health.health<3)
        {
          if(Input.GetKeyDown(KeyCode.Alpha1))
          {
          //Instantiate(effect, player.position, Quaternion.identity);
          Destroy(gameObject);
          health.health++;     
          }
        }
    }

}
