using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public DungeonDoorRange range;
    public GameObject Porta;
    

    void Awake()
    {
    }


    void Update()
    {
        if(DungeonDoorRange.onRadius == false)
        {
            Porta.SetActive(true);
            Destroy(gameObject, 0.1f);
        }
        
    }
}
