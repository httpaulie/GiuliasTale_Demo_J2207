using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cristal : MonoBehaviour
{
    public string sceneName;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
        SceneManager.LoadScene(sceneName);
        }
    }
}
