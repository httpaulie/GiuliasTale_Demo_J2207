using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot1 : MonoBehaviour
{
    private Inventory inventory;
    private Health health;
    public int i;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        if(transform.childCount <=0)
        {
            inventory.isFull[i] = false;
        }
        useItem();
    }

    public void useItem()
    {
        if(inventory.isFull[i] == true)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && health.health<3 && health.health>0)
            {
                foreach (Transform child in transform)
                {
                GameObject.Destroy(child.gameObject);
                }
                ++health.health;
            }
        }
    }

}
