using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos9 : MonoBehaviour
{
    public GameObject lugarCerto;
    public float distancia;
    public static bool encaixou9 = false;
    public GameObject som;
    int contador;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou9 = true;
        }
        if(encaixou9)
        {
            ++contador;
            if(contador<=1)
            {
                Instantiate(som, transform.position, transform.rotation);
            }
        } 
    }
}
