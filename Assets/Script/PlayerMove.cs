using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _speed;
   //public Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
//        _anim = GetComponent<Animator>();
    }
    void Mov()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), 0)*_speed*Time.deltaTime,Space.World);
//_anim.SetInteger("IsRun",(int) Input.GetAxisRaw("Horizontal"));//(int)强制转换
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }


    }
    // Update is called once per frame
    void Update()
    {
        Mov();
    }
}
