using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    //public Image profile;
    public Text speechText;
    public Text actorNameText;
    public static bool dialogueTrue;
    public static bool Acabou = false;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private string[] Actors;
    private int index;
    


    public void Speech(string[] txt, string[] actorName)
    {
        dialogueObj.SetActive(true);
        dialogueTrue = true;
        //profile.sprite = p;
        sentences = txt;
        //actorNameText.text = actorName;
        Actors = actorName;
        StartCoroutine(TypeSentence());
        NameSentence();
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private void NameSentence()
    {
        foreach (char letter in Actors[index].ToCharArray())
        {
            actorNameText.text += letter;
            //yield return null;
        }
    }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = "";
                StartCoroutine(TypeSentence());
                //StartCoroutine(NameSentence());
                NameSentence();

            }
            else
            {
                actorNameText.text = "";
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                dialogueTrue = false;
                Acabou = true;
            }
        }
    }
}


