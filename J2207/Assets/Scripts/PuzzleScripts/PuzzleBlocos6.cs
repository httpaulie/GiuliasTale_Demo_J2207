using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos6 : MonoBehaviour
{
    public GameObject lugarCerto;
    public float distancia;
    public static bool encaixou6 = false;
    public GameObject som;
    int contador;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou6 = true;
        }
        if(encaixou6)
        {
            ++contador;
            if(contador<=1)
            {
                Instantiate(som, transform.position, transform.rotation);
            }
        } 
    }
}
