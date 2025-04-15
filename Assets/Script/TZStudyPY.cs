using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TZStudyPY : MonoBehaviour
{
    public GameObject PanelPYMade;
    // Start is called before the first frame update
    void Start()
    {
        PanelPYMade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TiaoZhuanToStudyprocessPY()
    {
        SceneManager.LoadScene("Studyprocess");
    }
    public void BackToFirstOnclick()
    {
        SceneManager.LoadScene("First");
    }
    public void PYMade()
    {
        PanelPYMade.SetActive(true);
    }
    public void ClosePYMade()
    {
        PanelPYMade.SetActive(false);
    }
    public void ceshi1()
    {
        SceneManager.LoadScene("Level-4");
    }
    public void ceshi2()
    {
        SceneManager.LoadScene("SelfTest");
    }
}
