using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public DungeonDoorRange range;
    public GameObject Porta;
    public GameObject som;
    

    void Awake()
    {
    }


    void Update()
    {
        if(DungeonDoorRange.onRadius == false)
        {
            Instantiate(som, transform.position, transform.rotation);
            Porta.SetActive(true);
            Destroy(gameObject);
        }    
    }
}
