using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TZRule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelOnClick()
    {
        SceneManager.LoadScene("Level");

    }
    public void GuanbiOnClick()
    {
        SceneManager.LoadScene("Level0");

    }
}
