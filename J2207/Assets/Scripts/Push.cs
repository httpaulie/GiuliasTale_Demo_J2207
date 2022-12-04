using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public Transform pushPoint;
    public float radius;
    public float speed;
    public LayerMask playerLayer;
    private bool onRadius;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && onRadius == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pushPoint.transform.position, speed*Time.deltaTime);
        }
        Interact();
        
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
