using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    PuzzleBlocos encaixou;
    PuzzleBlocos1 encaixou1;
    PuzzleBlocos2 encaixou2;
    PuzzleBlocos3 encaixou3;
    public GameObject Porta;
    public GameObject som;


    void Start()
    {
    }

    void Update()
    {
        if(PuzzleBlocos.encaixou && PuzzleBlocos1.encaixou1 && PuzzleBlocos2.encaixou2 && PuzzleBlocos3.encaixou3)
        {
            Instantiate(som, transform.position, transform.rotation);
            Porta.SetActive(true);
            Destroy(gameObject);
        }
    }
}
