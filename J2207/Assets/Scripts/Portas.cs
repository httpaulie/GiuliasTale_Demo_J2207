using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    GameObject player;
    public GameObject door;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            player.transform.position = new Vector2(door.transform.position.x, door.transform.position.y);
        }
    }
}
