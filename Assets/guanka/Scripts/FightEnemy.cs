using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FightEnemy : MonoBehaviour
{
    [Header("Movement Settings")] public float moveSpeed = 5f;
    public float leftBound = -10f;
    public float rightBound = 10f;
    public float directionChangeInterval = 2f;

    [Header("Attack Settings")] public float attackInterval = 3f;
    public float meleeAttackRange = 2f;
    public float midAttackRange = 5f;

    [Header("Health Settings")] public int maxHp = 100;
    public int curHp = 100;
    public Image hpBar;

    public Animator baiguAnimator;
    public Transform playerTransform;
    private bool _isMovingRight;
    private bool _isIdle;
    private float _attackTimer;

    public Level2 level2;
    void Start()
    {
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            if (!_isIdle)
            {
                _isMovingRight = Random.value > 0.5f;
                if (transform.position.x <= leftBound) _isMovingRight = true;
                if (transform.position.x >= rightBound) _isMovingRight = false;
                directionChangeInterval = Random.Range(1f, 5f);
            }

            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        if (!_isIdle)
        {
            if (transform.position.x <= leftBound) _isMovingRight = true;
            if (transform.position.x >= rightBound) _isMovingRight = false;
            float direction = _isMovingRight ? 1 : -1;
            transform.Translate(moveSpeed * Time.deltaTime * direction * Vector2.right);
            baiguAnimator.SetBool("isrunning_left", !_isMovingRight);
            baiguAnimator.SetBool("isrunning_right", _isMovingRight);
        }
        else
        {
            baiguAnimator.SetBool("isrunning_left", false);
            baiguAnimator.SetBool("isrunning_right", false);
        }
    }

    void HandleAttack()
    {
        _attackTimer += Time.deltaTime;
        if (_attackTimer >= attackInterval)
        {
            _attackTimer = 0;
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        List<string> availableAttacks = new List<string>();
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        if (distance <= meleeAttackRange) availableAttacks.Add("melee");
        if (distance <= midAttackRange) availableAttacks.Add("range");

        if (availableAttacks.Count > 0)
        {
            _isIdle = true;
            string selectedAttack = availableAttacks[Random.Range(0, availableAttacks.Count)];

            if (selectedAttack == "melee")
            {
                baiguAnimator.SetTrigger("attack");
            }
            else
            {
                baiguAnimator.SetTrigger("effect1");
            }

            // 等待攻击动画时间
            yield return new WaitForSeconds(3f);
            _isIdle = false;
        }
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        ChangeHp(curHp, maxHp);
        

    }

    public void ChangeHp(int cur, int max)
    {       
        if (cur <= 0)
        {
            level2.GameOver(true);
        }
        hpBar.fillAmount = (float)cur / max;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WukongDamage"))
        {
            Damage damage = other.GetComponent<Damage>();
            if (damage) TakeDamage(damage.damage);
        }
    }
}