using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickBianXisuipian : MonoBehaviour
{
    public GameObject SishuiguanPanel;
    public GameObject BIANXIWPL;
    // Start is called before the first frame update
    void Start()
    {
        SishuiguanPanel.SetActive(false);
        BIANXIWPL.SetActive(false);
    }
    private void OnMouseDown()
    {
        SishuiguanPanel.SetActive(true);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseSISHUIGUANPanel()
    {
        SishuiguanPanel.SetActive(false); 
        BIANXIWPL.SetActive(true);
        Destroy(this.gameObject);
    }
}
