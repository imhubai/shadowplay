using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public float health = 3f;
  //  private bool characterDied;
    public GameObject LifePic1;
    public GameObject LifePic2;
    public GameObject LifePic3;
    public GameObject FailedPanel;
    public GameObject SuccessfulPanel;
    public Text t;
    public GameObject Arrowtext;

    private float time = 1f;
    private float timet = 60;
    private bool characterDied;
    // Start is called before the first frame update
    void Start()
    {
        FailedPanel.SetActive(false);
        SuccessfulPanel.SetActive(false);
            
            
            }

void Update()
    {
        Arrowtext.GetComponent<Text>().text = ArrowTrigger.Score.ToString();
        if (characterDied)
            return;
        if (timet > 0)
        {
            time -= Time.deltaTime;
            t.text = "" + timet;
        }
        if (time <= 0)
        {
            timet--;
            time = 1;
        }

        if (health==3)
        {
        LifePic1.SetActive(true);
        LifePic2.SetActive(true);
        LifePic3.SetActive(true); }
        if (health == 2)
            {
                LifePic1.SetActive(false);

            }

            if (health == 1)
            {
                LifePic1.SetActive(false);
                LifePic2.SetActive(false);
            }
            if (health == 0)
            {
                LifePic1.SetActive(false);
                LifePic2.SetActive(false);
                LifePic3.SetActive(false); }
           
        if (health <= 0 ||timet<=0)
        { 
         FailedPanel.SetActive(true);

            characterDied = true;
            ArrowTrigger.Score = 0;
            health = 3;

        }
        if (ArrowTrigger.Score == 10 && time >= 0)
        {
            SuccessfulPanel.SetActive(true);
            ArrowTrigger.Score = 0;
            health = 3;
            characterDied = true;


        }
    }
    public void CloseFailedPanel()
    {
        // FailedPanel.SetActive(false);
        SceneManager.LoadScene("Level");
        ArrowTrigger.Score = 0;
        health = 3;
    }
    
    }
