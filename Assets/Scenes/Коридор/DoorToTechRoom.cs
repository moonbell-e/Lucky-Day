using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToTechRoom : MonoBehaviour
{
    public BoolStorage bools;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Door To Room")
        {
            //if (gameObject.GetComponent<InteractPlayerController>().hasIsolenta == 1) // Если взяли изоленту
            if (bools.hasIsolenta)
            {
                SceneManager.LoadScene("TechLab_2");
            }

            else
            {
                SceneManager.LoadScene("TechLab");
            }
        }
    }
}