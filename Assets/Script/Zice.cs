using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Zice : MonoBehaviour
{
    public GameObject ONE;
    public GameObject TWO;
    public GameObject THREE;
    public GameObject FOUR;
    public GameObject panel1true;
    public GameObject panel1false;
    public GameObject panel2true;
    public GameObject panel2false;
    public GameObject panel3true;
    public GameObject panel3false;
    public GameObject panel4true;
    public GameObject panel4false;
    // Start is called before the first frame update
    void Start()
    {
        ONE.SetActive(true);
        TWO.SetActive(false);
        THREE.SetActive(false);
        FOUR.SetActive(false);
        panel1true.SetActive(false);
        panel1false.SetActive(false);
        panel2true.SetActive(false);
        panel2false.SetActive(false);
        panel3true.SetActive(false);
        panel3false.SetActive(false);
        panel4true.SetActive(false);
        panel4false.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button1TrueOnclick() {
       panel1true.SetActive(true);
    }
    public void Button1FalseOnclick1(){
    panel1false.SetActive(true); } 
    public void NextQuestionOnclick1()
    { ONE.SetActive(false);
        panel1true.SetActive(false);
        TWO.SetActive(true);
    }

    public void BackNextQuestionOnclick1()
    {
        ONE.SetActive(true);
        panel1false.SetActive(false);
    }
    public void Button2TrueOnclick()
    {
        panel2true.SetActive(true);
    }
    public void Button2FalseOnclick1()
    {
        panel2false.SetActive(true);
    }
   

    public void NextQuestionOnclick2()
    {
        TWO.SetActive(false);
        panel2true.SetActive(false);
        THREE.SetActive(true);
    }
    public void BackNextQuestionOnclick2()
    {
        TWO.SetActive(true);
        panel2false.SetActive(false);
    }
    public void Button3TrueOnclick()
    {
        panel3true.SetActive(true);
    }
    public void Button3FalseOnclick1()
    {
        panel3false.SetActive(true);
    }


    public void NextQuestionOnclick3()
    {
        THREE.SetActive(false);
        panel3true.SetActive(false);
        FOUR.SetActive(true);
    }
    public void BackNextQuestionOnclick3()
    {
       THREE.SetActive(true);
        panel3false.SetActive(false);
    }
    public void Button4TrueOnclick()
    {
        panel4true.SetActive(true);
    }
    public void Button4FalseOnclick1()
    {
        panel4false.SetActive(true);
    }


    public void NextQuestionOnclick4()
    {
        SceneManager.LoadScene("Start");
    }
    public void BackNextQuestionOnclick4()
    {
        THREE.SetActive(true);
        panel4false.SetActive(false);
    }
    public void EXITButtonOnclick()
    {
        SceneManager.LoadScene("First");
    }

}
