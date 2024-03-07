using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEntrance : MonoBehaviour
{
    PuzzleBlocos encaixou;
    PuzzleBlocos1 encaixou1;
    public GameObject Porta;
    public GameObject som;


    void Start()
    {
        
    }

    void Update()
    {
        if(PuzzleBlocos.encaixou && PuzzleBlocos1.encaixou1)
        {
            Instantiate(som, transform.position, transform.rotation);
            Porta.SetActive(true);
            Destroy(gameObject);
        }
    }
}
