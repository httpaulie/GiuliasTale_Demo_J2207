using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public bool CanShoot;
    public bool gamePaused;
    public PauseMenu pauseMenu;
    public GameObject Bala;
    public Transform NasceBala1;
    public Transform NasceBala2;
    public Transform NasceBala3;
    public static bool ganhouPoder = false;
    private int coolDown;
    DialogControl dc;
    public GameObject som;
 
    void Start()
    {
        CanShoot = true;
        coolDown = 0;
    }

    void Update()
    {
        mirar();
        atirar();
    }

    void mirar()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y,offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    void atirar()
    {

        if( CanShoot && Input.GetButtonDown("Fire1") && ganhouPoder)
        {
            CanShoot = false;
            Instantiate(Bala, NasceBala1.position, transform.rotation);
            Instantiate(som, NasceBala1.position, transform.rotation);
            
        }

        if( CanShoot == false)
        {
            ++coolDown;
            if(coolDown == 20)
            {
                CanShoot = true;
                coolDown = 0;
            }
        }

        if(PauseMenu.GameIsPaused == true)
        {
            CanShoot = false;
        }

        if(DialogControl.dialogueTrue == true)
        {
            CanShoot = false;
        }   
        
    }
}
