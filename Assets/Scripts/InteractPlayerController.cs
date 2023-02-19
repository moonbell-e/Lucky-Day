using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayerController : MonoBehaviour
{
    public float speed;
    public float height;
    public float bottomPoint;

    public Sprite[] directions;
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private Interaction interaction;
    private PlitaInteraction plita;

    Vector2 movement;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = spriteRenderer.sprite.rect.height;
        height *= 0.16f;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            if (nearestInteractive.name == "плита") /*ебаная*/
            {
                plita = nearestInteractive.GetComponent<PlitaInteraction>();
                plita.Interact();
            }
            else
            {
                interaction = nearestInteractive.GetComponent<Interaction>();
                interaction.Interact();
            }

        }
    }

    public int hasIsolenta = 0, hasFlashDrive = 0;
    void OnDisable()
    {
        PlayerPrefs.SetInt("hasIsolenta", hasIsolenta);
        PlayerPrefs.SetInt("hasFlashDrive", hasFlashDrive);
    }

    void OnEnable()
    {
        hasIsolenta = PlayerPrefs.GetInt("hasIsolenta");
        hasFlashDrive = PlayerPrefs.GetInt("hasFlashDrive");
    }

    void FixedUpdate()
    {
        //if isGameActive
        MovePlayer();
    }

    void MovePlayer()
    {
        // Перемещение
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        animator.SetFloat("SpeedX", Mathf.Abs(inputX));

        transform.Translate(Vector2.right * (inputX * speed * Time.fixedDeltaTime), Space.World);
        transform.Translate(Vector2.up * (inputY * speed * Time.fixedDeltaTime), Space.World);

        if (inputY > 0)
        {
            animator.SetFloat("SpeedY", (inputY));
            if (inputX > 0)
            {
                spriteRenderer.flipX = false;
                //spriteRenderer.sprite = directions[3]; // Up-Right 
            }

            if (inputX < 0)
            {
                spriteRenderer.flipX = true;
                //spriteRenderer.sprite = directions[0]; // Up-Left
            }
        }

        else
        {
            animator.SetFloat("SpeedY", (inputY));
            if (inputY < 0)
                animator.SetBool("IsMovingDown", true);
            else
                animator.SetBool("IsMovingDown", false);
            if (inputX > 0)
            {
                spriteRenderer.flipX = false;
                //spriteRenderer.sprite = directions[2]; // Down-Right
            }

            if (inputX < 0)
            {
                spriteRenderer.flipX = true;
                //spriteRenderer.sprite = directions[1]; // Down-Left
            }
        }
        
        /*if (inputX > 0.0f && inputY < 0.0f)
            spriteRenderer.sprite = directions[2]; // Down-Right
        if (inputX < 0.0f && inputY < 0.0f)
            spriteRenderer.sprite = directions[1]; // Down-Left
        if (inputX > 0.0f && inputY > 0.0f)
            spriteRenderer.sprite = directions[3]; // Up-Right
        if (inputX < 0.0f && inputY > 0.0f)
            spriteRenderer.sprite = directions[0]; // Up-Left*/

        height = spriteRenderer.sprite.rect.height / 16;
        bottomPoint = transform.position.y - height / 2;
        spriteRenderer.sortingOrder = -(int)(bottomPoint * 100);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactive"))
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
