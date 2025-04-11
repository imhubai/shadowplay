using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickWANGZHIsuipian : MonoBehaviour
{
    public GameObject XINGYANGPanel;
    public GameObject WANGZHIWPL;
   
    // Start is called before the first frame update
    void Start()
    {
        XINGYANGPanel.SetActive(false);
        WANGZHIWPL.SetActive(false);
      
    }
    private void OnMouseDown()
    {
      XINGYANGPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseXINGYANGPANELOnClick()
    {
        XINGYANGPanel.SetActive(false);
        WANGZHIWPL.SetActive(true);
       
     Destroy(this.gameObject);
    }
   
}
