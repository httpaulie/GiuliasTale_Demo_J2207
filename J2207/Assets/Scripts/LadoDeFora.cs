using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadoDeFora : MonoBehaviour
{
    public float radius = 2;
    public LayerMask playerLayer;
    public bool onRadius;
    public GameObject um;
    public GameObject dois;
    void Start()
    {
        
    }
    void Update()
    {
        Interact();
        if(onRadius)
        {
            um.SetActive(true);
            dois.SetActive(true);
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
