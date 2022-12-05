using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos5 : MonoBehaviour
{
    public GameObject lugarCerto;
    public float distancia;
    public static bool encaixou5 = false;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou5 = true;
        }
    }
}
