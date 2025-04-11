using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuccessfulUI : MonoBehaviour
{

    public GameObject CuRulePanel;


    // Start is called before the first frame update
    void Start()
    {
        CuRulePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {




    }
    public void CloseCuRuleButtonClick()
    {
        CuRulePanel.SetActive(false);
    }
}