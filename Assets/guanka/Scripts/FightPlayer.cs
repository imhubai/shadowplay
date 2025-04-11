using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FightPlayer : MonoBehaviour
{
    [Header("Movement Settings")] public float moveSpeed = 5f;
    private bool _isMovingLeft;
    private bool _isMovingRight;
    public int maxHp = 100;
    public int curHp = 100;
    public Image hpBar;
    
    public Animator animator;

    public Level2 level2;
    public void TakeDamage(int damage)
    {
        curHp -= damage;
        ChangeHp(curHp,this.maxHp);
    }

    public void ChangeHp(int cur, int max)
    {
        float value = cur * 1.0f / max;
        hpBar.fillAmount = value;
        if (cur <= 0)
        {
            level2.GameOver(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (other.CompareTag("EnemyDamage"))
        {
            TakeDamage(damage.damage);
        }
    }
    void Start()
    {
    }
    
    void Update()
    {
        HandleMovement();
        KeyboardMovement();
        
    }

    void KeyboardMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftButtonPressed();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightButtonPressed();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftButtonReleased();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightButtonReleased();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            AttackButtonClicked();
        }
    }


    private void HandleMovement()
    {
        Vector3 newPosition = transform.position;
        if (_isMovingLeft)
        {
            animator.SetBool("isrunning", true);
            newPosition += moveSpeed * Time.deltaTime * Vector3.left;
        }
        else if (_isMovingRight)
        {
            animator.SetBool("isrunning", true);
            newPosition += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else
        {
            animator.SetBool("isrunning", false);
        }

        transform.position = newPosition;
    }

    public void AttackButtonClicked() => animator.SetTrigger("attack");
    public void LeftButtonPressed() => _isMovingLeft = true;
    public void RightButtonPressed() => _isMovingRight = true;

    public void LeftButtonReleased() => _isMovingLeft = false;
    public void RightButtonReleased() => _isMovingRight = false;
}