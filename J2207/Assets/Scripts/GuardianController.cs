using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    [SerializeField] internal LifeManager lifeManager;

    public Transform fogePonto;
    Animator anim;
    public float radius3;
    public float speed;
    public LayerMask playerLayer;
    GameObject Player;
    public static bool isAlive;
    private Health health;
    public static bool onRange;

    void Awake()
    {
        lifeManager.OnDie += HandleDie;
    }

    private void HandleDie()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        isAlive = true;
    }

    void Update()
    {
       if(DialogControl.dialogueTrue == false)
       {
        Interact();
        if(onRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, fogePonto.transform.position, speed*Time.deltaTime);
        }
       } 
    }
    
    public void Interact()
    {
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
        Gizmos.DrawWireSphere(transform.position, radius3);
    }
}
