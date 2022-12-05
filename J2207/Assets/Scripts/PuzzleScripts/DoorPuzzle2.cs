using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle2 : MonoBehaviour
{
    PuzzleBlocos4 encaixou8;
    PuzzleBlocos5 encaixou9;
    PuzzleBlocos6 encaixou10;
    PuzzleBlocos7 encaixou11;
    public GameObject Porta;


    void Start()
    {
        
    }

    void Update()
    {
        if(PuzzleBlocos8.encaixou8 && PuzzleBlocos9.encaixou9 && PuzzleBlocos10.encaixou10 && PuzzleBlocos11.encaixou11)
        {
            Porta.SetActive(true);
            Destroy(gameObject);
        }
    }
}
