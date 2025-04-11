using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickQinqiSUIPIAN : MonoBehaviour
{
    public GameObject HuanghedukouPanel;
    public GameObject QINQIWPL;
    public GameObject SuccessfulPanel;
    // Start is called before the first frame update
    void Start()
    {
        HuanghedukouPanel.SetActive(false);
        QINQIWPL.SetActive(false);
        SuccessfulPanel.SetActive(false);
    }
    private void OnMouseDown()
    {
        HuanghedukouPanel.SetActive(true);
        QINQIWPL.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseHuanghedukouPanel()
    {
        HuanghedukouPanel.SetActive(false);
        SuccessfulPanel.SetActive(true);
    }
}
