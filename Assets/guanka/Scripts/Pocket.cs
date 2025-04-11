using System;
using Fungus;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [Header("Movement Settings")] 
    public float moveSpeed = 5f;
    public float leftBoundary = -5f;
    public float rightBoundary = 5f;
    public float smoothTime = 0.3f;
    public float maxTiltAngle = 15f;
    public float tiltReturnSpeed = 2f;
    public Level3 levelController;

    private Vector3 velocity = Vector3.zero;
    private float velocityX;

    void Update()
    {
        if (levelController.isStart)
        {
            MouseMovement();
        }
    }

    void MouseMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        targetPosition.x = Mathf.Clamp(targetPosition.x, leftBoundary, rightBoundary);
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime,
            moveSpeed
        );
        
        velocityX = Mathf.Lerp(velocityX, velocity.x, Time.deltaTime * 10f);
        
        float targetTilt = -velocityX * maxTiltAngle;
        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, 0, targetTilt);
        
        transform.rotation = Quaternion.Lerp(
            currentRot,
            targetRot,
            tiltReturnSpeed * Time.deltaTime
        );
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropItem"))
        {
            GameObject o = other.gameObject;
            ItemDrop itemDrop = o.GetComponent<ItemDrop>();
            levelController.SendMessage("PointChange", itemDrop.point);
            Destroy(other.gameObject);
        }
    }
}