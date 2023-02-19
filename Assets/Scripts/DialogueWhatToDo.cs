using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueWhatToDo : MonoBehaviour
{
    public GameObject dialogueWhatToDo;

    void Start()
    {
        dialogueWhatToDo.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return)))
        {
            dialogueWhatToDo.SetActive(false);
        }
    }

    public void Hint()
    {
        dialogueWhatToDo.SetActive(true);
    }
}
