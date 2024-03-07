using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlocos7 : MonoBehaviour
{
    public GameObject lugarCerto;
    public float distancia;
    public static bool encaixou7 = false;
    public GameObject som;
    int contador;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, lugarCerto.transform.position);

        if(distancia <= 0.5)
        {
            encaixou7 = true;
        }
        if(encaixou7)
        {
            ++contador;
            if(contador<=1)
            {
                Instantiate(som, transform.position, transform.rotation);
            }
        } 
    }
}
