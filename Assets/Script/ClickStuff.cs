using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStuff : MonoBehaviour
{
    public GameObject HanFuWPL;
    public GameObject MengTanWPL;
    public GameObject LuoYangChengPanel;
    // Start is called before the first frame update
    void Start()
    {
        LuoYangChengPanel.SetActive(false);
        MengTanWPL.SetActive(false);
       HanFuWPL.SetActive(false);
    }
    private void OnMouseDown()
    {
        LuoYangChengPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseLYCPanelOnClick()
    {
        LuoYangChengPanel.SetActive(false);
        MengTanWPL.SetActive(true);
        HanFuWPL.SetActive(true);
        Destroy(this.gameObject);
    }

}
