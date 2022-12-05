using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianGun : MonoBehaviour
{
    public GameObject Bala;
    public Transform NasceBala1;
    GameObject player;
    EnemyController2 control;
    DialogControl dialogue;
    int tempopatirar;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Shoot();
        Aim();
    }

    void Aim()
    {
        Quaternion rotation = Quaternion.LookRotation
        (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    void Shoot()
    {
        if(DialogControl.dialogueTrue == false && PauseMenu.GameIsPaused == false)
        {
            if(tempopatirar >= 180)
            {
                Instantiate(Bala, NasceBala1.position, transform.rotation);
                tempopatirar = 0;
            }
        }   ++tempopatirar;  
    }
}
