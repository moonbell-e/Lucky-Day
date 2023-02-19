using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlitaInteraction : MonoBehaviour
{
    public GameObject skovorodka;
    public Sprite Normal, Burned;
    private SpriteRenderer _spriteRenderer;

    public DialogueTrigger trigger;

    private GameObject currentSkovorodka;

    public int count;
    
    void Start()
    {
        count = 0;
    }

    public void Interact()
    {
        if (transform.childCount == 0) // Если сковородка не стоит
        {
            currentSkovorodka = Instantiate(skovorodka, gameObject.transform);
            _spriteRenderer = currentSkovorodka.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = Normal;
            FindObjectOfType<AudioManager>().Play("Breakfast");
        }
        else // Если сковородка стоит
        {
            Destroy(currentSkovorodka);
        }
    }

    public void BurnSkovorodka()
    {
        _spriteRenderer.sprite = Burned;
        count++;
    }
    
    public IEnumerator BurnTimer()
    {
        if (transform.childCount == 0) yield break;
        yield return new WaitForSeconds(1);
        BurnSkovorodka();
    }
}
