using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SanyingButtonOnclick()
    {
        SceneManager.LoadScene("LightRule");

    }

    public void CuxiButtonOnclick()
    {
        SceneManager.LoadScene("Found");

    }
    public void CaochuanOnclick()
    {
        SceneManager.LoadScene("BoatRule");

    }
    public void BacktoXitongOnclick()
    {
        SceneManager.LoadScene("First");

    }
}
