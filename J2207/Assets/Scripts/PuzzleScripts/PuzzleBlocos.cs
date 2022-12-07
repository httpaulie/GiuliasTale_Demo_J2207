using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos : MonoBehaviour
{
    public GameObject lugarCerto;
    float distancia;
    public static bool encaixou = false;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou = true;
        }
    }
}
