using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float radius;
    public GameObject F;
    public LayerMask interactiveLayer;
    bool onRadius;
    Animator anim;
    public Rigidbody2D playerRb;
    public float speed = 5f;
    Vector2 movimento;
    private DialogControl dialog;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        Interact();
    }

    void Update()
    {
        if(DialogControl.dialogueTrue == false){
        move();
        }
        Animation();
        CameraFollow();
  
        if(onRadius)
        {
            F.SetActive(true);
        }else F.SetActive(false);
    }

    void move()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");
        playerRb.MovePosition(playerRb.position + movimento * speed * Time.fixedDeltaTime);
    }

    void Animation()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        anim.SetBool("IsMoving", (Mathf.Abs(movimento.x)>0 || Mathf.Abs(movimento.y)>0));
    }

    void CameraFollow()
    {
        CameraPosition.instance.SetPosition(new Vector2(transform.position.x, transform.position.y));
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, interactiveLayer);

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
