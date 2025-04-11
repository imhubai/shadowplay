using System;
using UnityEngine;

/// <summary>
/// Level1关卡使用的碰撞检测
/// </summary>
public class Player : MonoBehaviour
{
    public Level1 level1;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            level1.SendMessage("ChangeHp", -1);
        }
        else if (other.CompareTag("BifengBall"))
        {
            level1.SendMessage("ChangePoint", 1);
            Destroy(other.gameObject);
        }
    }
}