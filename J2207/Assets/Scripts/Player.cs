using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public Rigidbody2D playerRb;
    public float speed = 5f;
    Vector2 movimento;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Animation();
        CameraFollow();
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
}
