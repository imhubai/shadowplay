using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    Rigidbody2D rig;
   // private Animator anim;  //动画组件
    public float moveSpeed;
    public float move;
 //  private bool Ground = true;
    public float JumpForce;
    private bool FacingRight = true;
    public GameObject Yun;
    public GameObject Chuan;
    public GameObject BoxLock;
   public GameObject BoxOpen;
    public GameObject WoodBoxLock;
    public GameObject WoodBoxOpen;
    public bool isTizi;
    public Animator animator;
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    // public AudioClip dakaixiangzi;

    public List<LearnChara> LearnCharaList;

    public float triggerLearnCharaDistance;
    // Start is called before the first frame update
    void Start()
    {
        isTizi = false;
        BoxLock.SetActive(true);
        BoxOpen.SetActive(false);
        WoodBoxLock.SetActive(true);
        WoodBoxOpen.SetActive(false);
        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件
        
     // anim = GetComponent<Animator>();
    

        JumpForce = 100f;
       Yun.SetActiveRecursively(true);

        animator = this.gameObject.GetComponent<Animator>();
       
    }
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var chara in LearnCharaList)
            {
                if (Vector3.Distance(this.transform.position, chara.transform.position) < triggerLearnCharaDistance)
                {
                    chara.ShowLearnUI();
                }
            }
        }
    }

    void FixedUpdate()
    {
       

        float horizontal = Input.GetAxis("Horizontal");   //水平方向按键偏移量
        move = horizontal * moveSpeed;   //刚体具体速度
        rig.velocity = new Vector2(move * moveSpeed*Time.deltaTime, rig.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))//&& Ground == true)
        {
            rig.AddForce(new Vector2(0, JumpForce));
            Yun.SetActive(true);
        }

 
        if (horizontal > 0 && !FacingRight) //向右Right动画
        {
            Flip();
             //anim.SetBool("IsRight", true);
           //anim.SetBool("IsLeft", false);
        }

        else if (horizontal < 0 && FacingRight)//向左Left动画
        {
            //anim.SetBool("IsLeft", true);
           //anim.SetBool("IsRight", false);
            Flip();
        }
        animator.SetInteger("horizontal", (int)horizontal);
        animator1.SetInteger("horizontal", (int)horizontal);
        animator2.SetInteger("horizontal", (int)horizontal);
        animator3.SetInteger("horizontal", (int)horizontal);
        animator4.SetInteger("horizontal", (int)horizontal);
    }
   public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
                  Yun.SetActiveRecursively(false);
            Chuan.SetActiveRecursively(false);
            // gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "tangseng")
        {
            collision.gameObject.SetActive(false);
            animator1.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "ma")
        {
            collision.gameObject.SetActive(false);
            animator4.gameObject.SetActive(true);
            transform.GetChild(3).position += new Vector3(-1, 0,0);
        }
        if (collision.gameObject.tag == "bajie")
        {
            collision.gameObject.SetActive(false);
            animator2.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "shaseng")
        {
            collision.gameObject.SetActive(false);
            animator3.gameObject.SetActive(true);
            transform.GetChild(3).position += new Vector3(-1, 0, 0);
        }
        if (collision.gameObject.tag == "yaoguai")
        {
            collision.gameObject.SetActive(false);
         
        }
        // Ground = true;
        if (collision.gameObject.tag == "Box"){
            BoxLock.SetActive(false);
          //  AudioSource.PlayClipAtPoint(dakaixiangzi, transform.position);
            BoxOpen.SetActive(true);}
        if (collision.gameObject.tag == "WoodBox")
        {WoodBoxLock.SetActive(false);
            //AudioSource.PlayClipAtPoint(dakaixiangzi, transform.position)
            WoodBoxOpen.SetActive(true);}

        if (collision.gameObject.tag == "zhongdian")
        {
            SceneManager.LoadScene("Level");
            
        }







        //Yun.SetActiveRecursively(false);


        /* if (collision.gameObject.tag == "suipian")
         {

             HuanghedukouPanel.SetActive(true);
             QINQIWPL.SetActive(true);

         }*/

        if (collision.gameObject.tag == "Wave")
          {
             
              Chuan.SetActive(true);
           
          }


    }

    public void Flip()
        {

            FacingRight = !FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }
    

}

