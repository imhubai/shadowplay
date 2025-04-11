using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 物品延时掉落
/// </summary>
public class ItemDrop : MonoBehaviour
{
    // 物品分数
    public int point = 1;
    // 延时时间
    public float dropTime = 2f;
    // 掉落速度(重力倍率)
    [Range(0,100)]
    public float dropSpeed = 1f;
    private Rigidbody2D _rigidbody2d;
    
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _rigidbody2d.gravityScale = 0;
        StartCoroutine(Wait(dropTime));
    }
    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        
        Drop();
    }

    void Drop()
    {
        _rigidbody2d.gravityScale = dropSpeed;
    }

    private void Update()
    {
        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
