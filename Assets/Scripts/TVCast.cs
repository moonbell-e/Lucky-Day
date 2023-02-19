using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVCast : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private DialogueTrigger trigger;
    public GameObject TV;

    public Animator animator;

    public Interaction interaction;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            if (TV.gameObject.GetComponent<SpriteRenderer>().sprite == interaction.turnedOff)
            {
                trigger = nearestInteractive.GetComponent<DialogueTrigger>();
                trigger.TriggerDialogue();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "телек")
        {
            nearestInteractive = other.gameObject;
            pressEToInteract.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        pressEToInteract.SetActive(false);
        nearestInteractive = null;
    }
}
