using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public float speed;

    public int positionOfPatrool;
    public Transform point;
    bool movingRight;

    public Animator animator;
    private Rigidbody rb;

    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrool && angry == false)
        {
            chill = true;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, point.position) > positionOfPatrool)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        if (angry == true)
        {
            Angry();
        }
        if (goBack == true)
        {
            GoBack();
        }
    }

    void Chill()
    {
        animator.SetBool("isRunning", true);
        if (transform.position.x > point.position.x + positionOfPatrool)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrool)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.localScale = new Vector2(0.7f, 0.6f);
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.localScale = new Vector2(-0.7f, 0.6f);
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    void Angry()
    {
        animator.SetBool("isRunning", true);

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * 2 * Time.deltaTime);

        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector2(0.7f, 0.6f);

        }
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector2(-0.7f, 0.6f);

        }
    }

    void GoBack()
    {
        animator.SetBool("isRunning", true);
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}
