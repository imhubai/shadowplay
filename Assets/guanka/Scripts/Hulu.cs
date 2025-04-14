using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hulu : MonoBehaviour
{
    [Header("吸收设置")]
    public Transform targetPoint;
    public float absorbDuration = 1f;
    public AnimationCurve scaleCurve = AnimationCurve.Linear(0, 1, 1, 0);

    //TEST
    public GameObject enemy;
    private void Start()
    {
        GetEnemy(enemy);
    }

    public void GetEnemy(GameObject enemy)
    {
        StartCoroutine(AbsorbEnemy(enemy.transform));
    }
    
    IEnumerator AbsorbEnemy(Transform enemy)
    {
        // 禁用敌人的物理和碰撞
        DisablePhysics(enemy);

        Vector3 startPosition = enemy.position;
        Vector3 startScale = enemy.localScale;
        Quaternion quaternion = enemy.rotation;
        float elapsed = 0f;

        while (elapsed < absorbDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / absorbDuration;
            
            Vector3 currentTarget = targetPoint.position;
            
            enemy.position = Vector3.Lerp(
                currentTarget, 
                startPosition, 
                scaleCurve.Evaluate(t)
            );
            
            enemy.localScale = Vector3.Lerp(
                Vector3.zero, 
                startScale, 
                scaleCurve.Evaluate(t)
            );

            enemy.localRotation = Quaternion.Lerp(
                Quaternion.Euler(0,0,90f),
                quaternion,
                scaleCurve.Evaluate(t)
            );
            
            yield return null;
        }

        Destroy(enemy.gameObject);
    }

    void DisablePhysics(Transform enemy)
    {
        // 禁用刚体物理
        if (enemy.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }

        // 禁用所有碰撞器
        foreach (var collider in enemy.GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }
}