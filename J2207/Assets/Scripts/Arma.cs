using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public bool CanShoot;
    private int coolDown;
    public PauseMenu pauseMenu;
    public GameObject Bala;
    public Transform NasceBala1;
    public Transform NasceBala2;
    public Transform NasceBala3;
 
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
        if(PauseMenu.GameIsPaused == false){
            if( CanShoot && Input.GetButtonDown("Fire1"))
            {
                CanShoot = false;
                Instantiate(Bala, NasceBala1.position, transform.rotation);
                Instantiate(Bala, NasceBala2.position, NasceBala2.rotation);
                Instantiate(Bala, NasceBala3.position, NasceBala3.rotation);
            }
            if( CanShoot == false)
            {
                ++coolDown;
                if(coolDown == 60)
                {
                    CanShoot = true;
                    coolDown = 0;
                }
            }
        }
        
    }
}
