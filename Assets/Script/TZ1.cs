using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TZ1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StudyButtonOnclick()
    {
        SceneManager.LoadScene("Study");

    }

    public void GameButtonOnclick()
    {
        SceneManager.LoadScene("Level");

    }
    public void TestOnclick()
    {
        SceneManager.LoadScene("test2");

    }
    public void BacktoOnclick()
    {
        SceneManager.LoadScene("Start");

    }


}
