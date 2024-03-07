using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public static CameraPosition instance;

    void Awake()
    {
      if(instance == null)
      {
        instance = this;
      }else{
        Destroy(instance);
      }
    }


    public void SetPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
