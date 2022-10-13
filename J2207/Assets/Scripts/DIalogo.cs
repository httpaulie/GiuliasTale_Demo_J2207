using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogo : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject Player;
    public GameObject NPC;
    [SerializeField] float distancia;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Distancia();
    }

    void Distancia()
    {
        distancia = Vector2.Distance(NPC.transform.position, Player.transform.position);

        if(distancia < 1.5)
        {
            sprite.enabled = true;
        }else sprite.enabled = false;
    }
}
