using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cena3 : MonoBehaviour
{
    public float radius = 2;
    public LayerMask playerLayer;
    public bool onRadius;
    public GameObject um;
    void Start()
    {
        
    }
    void Update()
    {
        Interact();
        if(onRadius)
        {
            Arma.ganhouPoder = true;
            um.SetActive(true);
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
