using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StudyClick : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject e;
    public GameObject f;
    public GameObject g;
    public GameObject h;
    // Start is called before the first frame update
    void Start()
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(false);
        e.SetActive(false);
        f.SetActive(false);
        g.SetActive(false);
        h.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToStudyBtnOnclick()
    {
        SceneManager.LoadScene("Study");
    }

    public void StepBtnOnClick1()
    {
        a.SetActive(true);
    }

    public void CloseStepBtnOnClick1()
    {
        a.SetActive(false);
    }
    public void StepBtnOnClick2()
    {
        b.SetActive(true);
    }

    public void CloseStepBtnOnClick2()
    {
        b.SetActive(false);
    }
    public void StepBtnOnClick3()
    {
        c.SetActive(true);
    }

    public void CloseStepBtnOnClick3()
    {
        c.SetActive(false);
    }
    public void StepBtnOnClick4()
    {
       d.SetActive(true);
    }

    public void CloseStepBtnOnClick4()
    {
        d.SetActive(false);
    }
    public void StepBtnOnClick5()
    {
        e.SetActive(true);
    }

    public void CloseStepBtnOnClick5()
    {
        e.SetActive(false);
    }
    public void StepBtnOnClick6()
    {
        f.SetActive(true);
    }

    public void CloseStepBtnOnClick6()
    {
        f.SetActive(false);
    }
    public void StepBtnOnClick7()
    {
        g.SetActive(true);
    }

    public void CloseStepBtnOnClick7()
    {
        g.SetActive(false);
    }
    public void StepBtnOnClick8()
    {
        h.SetActive(true);
    }

    public void CloseStepBtnOnClick8()
    {
        h.SetActive(false);
    }
}
