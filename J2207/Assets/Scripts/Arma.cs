using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject Bala;
    public Transform NasceBala;
 
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
            if(Input.GetButtonDown("Fire1"))
            {
                Instantiate(Bala, NasceBala.position, transform.rotation);
            }
        }
        
    }
}
