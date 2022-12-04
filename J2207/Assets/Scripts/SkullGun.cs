using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGun : MonoBehaviour
{
    public GameObject Bala;
    public Transform NasceBala1;
    GameObject player;
    EnemyController2 control;
    int tempopatirar;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       if(DialogControl.dialogueTrue == false)
       { 
        if(EnemyController2.onRange == true)
        {   
            Shoot();
        }
        Aim();
       } 
    }

    void Aim()
    {
        Quaternion rotation = Quaternion.LookRotation
        (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    void Shoot()
    {
        
        if(tempopatirar >= 90)
        {
            Instantiate(Bala, NasceBala1.position, transform.rotation);
            tempopatirar = 0;
        }
        ++tempopatirar;  
    }
}
