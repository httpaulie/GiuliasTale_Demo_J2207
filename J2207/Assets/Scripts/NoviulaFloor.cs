using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NoviulaFloor : MonoBehaviour
{
    public string sceneName;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
