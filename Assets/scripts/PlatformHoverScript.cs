using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHoverScript : MonoBehaviour
{
    private bool dirRight = true;
    private bool dirUp = true;

    public float speed = 1.0f;

    [Header("How many units to left and right")]
    public float moveLeftUnits = 1;
    public float moveRightUnits = 1;


    [Header("How many units to go up and down")]
    public float moveUpUnits = 1;
    public float moveDownUnits = 1;


    [Header("True = up/down | False = left/right")]
    public bool moveUpAndDownOrMoveLeftAndRight = true;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moveUpAndDownOrMoveLeftAndRight == true)
        {
            MoveUpAndDown();
        }
        if (moveUpAndDownOrMoveLeftAndRight == false)
        {
            MoveRightAndLeft();
        }
    }

    void MoveUpAndDown()
    {

        if (dirUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (transform.position.y >= startPos.y + moveUpUnits)
        {
            dirUp = false;
        }

        if (transform.position.y <= startPos.y - moveDownUnits)
        {
            dirUp = true;
        }
    }

    void MoveRightAndLeft()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (transform.position.x >= startPos.x + moveRightUnits)
        {
            dirRight = false;
        }

        if (transform.position.x <= startPos.x - moveLeftUnits)
        {
            dirRight = true;
        }
    }
}