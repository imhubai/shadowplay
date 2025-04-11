using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public Text t1;
    private float timer = 1f;
    public static float timet1 = 15;
    public GameObject Failedpanel;

    public GameObject jishiqipanel;

    // Start is called before the first frame update
    void Start()
    {
        Failedpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timet1 > 0)
        {
            timer -= Time.deltaTime;
            t1.text = "" + timet1;
        }

        if (timet1 <= 0)

        {
            Failedpanel.SetActive(true);
            jishiqipanel.SetActive(false);
        }

        if (timer <= 0)
        {
            timet1--;
            timer = 1;
        }
    }

    public void GuanbiYOUXIOnClick()
    {
        SceneManager.LoadScene("Level");
        Failedpanel.SetActive(false);
        timet1 = 15;
    }
}