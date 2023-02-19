using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class DoorToNextScene : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _spriteColor;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;


    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Дверь наружу")
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