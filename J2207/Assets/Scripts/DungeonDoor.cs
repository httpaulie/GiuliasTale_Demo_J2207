using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoor : MonoBehaviour
{
    public DungeonDoorRange range;
    public GameObject Porta;

    void Start()
    {
        
    }


    void Update()
    {
        if(DungeonDoorRange.onRadius == false)
        {
            Porta.SetActive(true);
            Destroy(gameObject);
        }
    }
}
