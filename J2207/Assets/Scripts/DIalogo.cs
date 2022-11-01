using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogo : MonoBehaviour
{
    public static bool dialogPause = false;
    public GameObject DialogMenuUI;
    private Player player;
    [SerializeField] float distancia;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        Distancia();
    }

    void Distancia()
    {
        distancia = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if(distancia < 1.5 )
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(dialogPause)
                {
                    Resume();
                } else
                {
                    Pause();
                }

            }
        }
    }

    public void Resume()
    {
        DialogMenuUI.SetActive(false);
        Time.timeScale = 1f;
        dialogPause = false;
    }

    void Pause()
    {
        DialogMenuUI.SetActive(true);
        Time.timeScale = 0f;
        dialogPause = true;
    }

}
