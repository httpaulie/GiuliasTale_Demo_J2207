using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //public Sprite profile;
    public string[] speechText;
    public string actorName;

    public LayerMask playerLayer;
    public float radius;

    private DialogControl dc;
    bool onRadius;

    private void Start()
    {
        dc = FindObjectOfType<DialogControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && onRadius)
        {
            dc.Speech( speechText, actorName);
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
