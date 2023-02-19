using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMoving : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D _collider2D;

    public float height;
    public float bottomPoint;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = spriteRenderer.sprite.rect.height / 16;
        bottomPoint = transform.position.y - height / 2;
        spriteRenderer.sortingOrder = -(int)(bottomPoint * 100);
        //spriteRenderer.sortingOrder -= (int)(height / 2.0f);
    }
}