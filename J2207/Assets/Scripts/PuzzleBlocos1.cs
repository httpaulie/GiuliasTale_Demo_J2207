using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos1 : MonoBehaviour
{
    public GameObject lugarCerto;
    public float distancia;
    public static bool encaixou1 = false;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou1 = true;
        }
    }
}
