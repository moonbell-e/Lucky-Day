using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Sprite turnedOn, turnedOff;
    private SpriteRenderer _spriteRenderer;
    

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = turnedOff;
    }

    

    public void Interact()
    {
        if (_spriteRenderer.sprite == turnedOff)
        {
            _spriteRenderer.sprite = turnedOn;
        }
        else
        {
            _spriteRenderer.sprite = turnedOff;
        }
    }
}
