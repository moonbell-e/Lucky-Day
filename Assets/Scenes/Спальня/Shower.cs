using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public GameObject plita;
    private Color _spriteColor;
    public bool isShowering = false;


    public GameObject pressEToInteract;
    private GameObject nearestInteractive;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteColor = _spriteRenderer.color;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            {
                pressEToInteract.SetActive(false);
                StartCoroutine(plita.GetComponent<PlitaInteraction>().BurnTimer());
                Invisible();
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shower"))
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
    void Invisible()
    {
         FindObjectOfType<AudioManager>().Play("Shower");
         pressEToInteract.SetActive(false);
        isShowering = true;
         _spriteColor.a = 0f;
         _spriteRenderer.color = _spriteColor;
         GetComponent<InteractPlayerController>().enabled = false;
         StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(9);
        _spriteColor.a = 1;
        _spriteRenderer.color = _spriteColor;
        StopCoroutine("Timer");
        GetComponent<InteractPlayerController>().enabled = true;
        pressEToInteract.SetActive(false);
    }
}
