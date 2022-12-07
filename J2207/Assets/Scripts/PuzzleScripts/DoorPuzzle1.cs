using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle1 : MonoBehaviour
{
    PuzzleBlocos4 encaixou4;
    PuzzleBlocos5 encaixou5;
    PuzzleBlocos6 encaixou6;
    PuzzleBlocos7 encaixou7;
    public GameObject Porta;
    public GameObject som;


    void Start()
    {
        
    }

    void Update()
    {
        if(PuzzleBlocos4.encaixou4 && PuzzleBlocos5.encaixou5 && PuzzleBlocos6.encaixou6 && PuzzleBlocos7.encaixou7)
        {
            Instantiate(som, transform.position, transform.rotation);
            Porta.SetActive(true);
            Destroy(gameObject);
        }
    }
}
