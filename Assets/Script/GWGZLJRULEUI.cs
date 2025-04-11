using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GWGZLJRULEUI : MonoBehaviour
{
    public GameObject dianguUI;
    public GameObject gaituUI;
    public GameObject GYRuleUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void diangunextButtonOnClick()
    {
        dianguUI.SetActive(false);
    }
    public void gaituUIshangyiyeOnClick()
    {
        dianguUI.SetActive(true);
    }
    public void gaituUIxiayiyeOnClick()
    {
        gaituUI.SetActive(false);
    }
    public void GYRuleshangyiyeOnClick()
    {
        gaituUI.SetActive(true);
    }
    public void GuanbiRuleOnClick()
    {
        SceneManager.LoadScene("Light");

    }
}
