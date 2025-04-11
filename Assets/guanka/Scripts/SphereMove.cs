using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public float speed = 1f;
    public float restartDelay = 1f;
    private bool _isMovingForward = true;

    void Start()
    {
    }

    private void Update()
    {
        StartMovement();
    }

    void StartMovement()
    {
        Vector3 aimVec = Vector3.right;
        if (!_isMovingForward)
        {
            aimVec = Vector3.left;
        }
        this.transform.position += speed * Time.deltaTime * aimVec;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("speechWall"))
        {
            StartCoroutine(RestartMovementAfterDelay());
        }
    }

    IEnumerator RestartMovementAfterDelay()
    {
        _isMovingForward = false;
        StartMovement();
        yield return new WaitForSeconds(restartDelay);
        _isMovingForward = true;
    }
}