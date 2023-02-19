using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public GameObject elevatorMenuUI;

    private GameObject nearestInteractive;
    public static bool isElevatorWindowOn = false;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;

    void ElevatorWindowOn()
    {
        elevatorMenuUI.SetActive(true);
        isElevatorWindowOn = true;
    }
    void ElevatorWindowOff()
    {
        elevatorMenuUI.SetActive(false);
        isElevatorWindowOn = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elevator"))
        {
            nearestInteractive = other.gameObject;
            elevatorMenuUI.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        elevatorMenuUI.SetActive(false);
        nearestInteractive = null;
    }
    public void ChoiceOption1()
    {
        SceneManager.LoadScene("Warehouse");
    }

    public void ChoiceOption2()
    {
        if (SceneManager.GetActiveScene().name != "Hall")
        {
            SceneManager.LoadScene("Hall_2");
        }
    }

    public void ChoiceOption3()
    {
        SceneManager.LoadScene("Corridor");
    }
    public void ChoiceOption4()
    {
        if (SceneManager.GetActiveScene().name == "Hall")
        {
            SceneManager.LoadScene("Boss room");
        }

        else 
        {
            SceneManager.LoadScene("Boss_room_2");
        }
    }
}


