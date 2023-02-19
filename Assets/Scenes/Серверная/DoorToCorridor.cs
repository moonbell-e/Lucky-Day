using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToCorridor : MonoBehaviour
{
    //public int timeToStop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Corridor")
        {
            SceneManager.LoadScene("Corridor");
        }
    }
}

