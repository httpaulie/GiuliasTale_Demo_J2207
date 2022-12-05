using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSword : MonoBehaviour
{
    GuardianController control;
    GameObject player;
    Animator anim;
    Health health;
    public GameObject Guardian;
    int coolDown;
    public float speed;
    public float speedBack;
    
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if(DialogControl.dialogueTrue == false)
        {
          if(GuardianController.onRange)
          { 
            ++coolDown;
            if(coolDown > 300 && coolDown < 480)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
            }
            if(coolDown >= 480)
            {
                transform.position = Vector2.MoveTowards(transform.position, Guardian.transform.position, speedBack*Time.deltaTime);
            }
            if(coolDown >=540)
            {
                coolDown = 0;
            }
          }
        anim.SetBool("IsAttacking", coolDown >= 300);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Player.Levou == false)
        {
            health.health--;
            Player.Levou = true;
        }
    }
    
}
