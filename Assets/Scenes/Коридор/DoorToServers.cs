using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToServers : MonoBehaviour
{
    public BoolStorage bools;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Door To Servers")
        {
            //if (gameObject.GetComponent<InteractPlayerController>().hasFlashDrive == 1) // Если взяли флешку
            if (bools.hasFlashDrive)
            {
                SceneManager.LoadScene("Server_room_2");
            }

            else
            {
                SceneManager.LoadScene("Servers room");
            }
        }
    }

}
