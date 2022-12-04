using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //public Sprite profile;
    public string[] speechText;
    public string[] actorName;
    public string[] speechText1;
    public string[] actorName1;
    public bool Acabou = false;

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
        if(DialogControl.dialogueTrue == false)
        {
            if(onRadius && Input.GetKeyDown(KeyCode.F))
            {
                    
                    if(Acabou == false)
                    {
                        dc.Speech(speechText, actorName);
                        Acabou = true;
                    }else
                     {
                        dc.Speech(speechText1, actorName1);
                     }
            }
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
