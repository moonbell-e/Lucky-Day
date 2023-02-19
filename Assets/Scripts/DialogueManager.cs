using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    private Queue<string> names;

    public Animator animator;


    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return)))
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.lines[dialogue.lines.Length-1].name;
        sentences.Clear();
        foreach (var line in dialogue.lines)
        {
            names.Enqueue(line.name);
            foreach (string sentence in line.text)
            {
                sentences.Enqueue(sentence);
            }
        }
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        nameText.text = names.Dequeue();
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
