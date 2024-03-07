using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoorRange : MonoBehaviour
{
    public float radius;
    public LayerMask enemyLayer;
    public static bool onRadius;
    
    void Awake()
    {
        Interact();
    }

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, enemyLayer);

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
