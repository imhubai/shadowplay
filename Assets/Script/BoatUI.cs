using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoatUI : MonoBehaviour
{
   // public GameObject PanelBoatRule;
   


    // Start is called before the first frame update
    void Start()
    {
       
       // PanelBoatRule.SetActive(true);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void ClosePanelBoatRule()
    {
        PanelBoatRule.SetActive(false);
        
        }*/
    public void ExitLevelButtonOnclick()
    {
        SceneManager.LoadScene("Level");
    }
}
