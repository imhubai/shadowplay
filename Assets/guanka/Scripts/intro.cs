using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    public GameObject introBaseCanvas;

    public GameObject dialoguePage;
    public GameObject buttonLast;
    public GameObject buttonNext;
    public GameObject buttonOk;

    public List<GameObject> pages;
    public int index = 0;

    void Start()
    {
        this.buttonLast.SetActive(false);
        HideAllPages();
        pages[0].SetActive(true);
    }

    void Update()
    {
    }
    

    public void ClickOk()
    {
        this.introBaseCanvas.SetActive(false);
        dialoguePage.SetActive(true);
    }

    public void HideAllPages()
    {
        foreach (GameObject p in pages)
        {
            p.SetActive(false);
        }
    }
    
    public void ClickLast()
    {
        if (index > 0)
        {
            index--;
            HideAllPages();
            buttonOk.SetActive(false);
            buttonNext.SetActive(true);
            pages[index].SetActive(true);
            if (index == 0)
            {
                buttonLast.SetActive(false);
            }
        }
    }

    public void ClickNext()
    {
        if (index < pages.Count-1)
        {
            index++;
            HideAllPages();
            pages[index].SetActive(true);
            if (index == pages.Count-1)
            {
                buttonNext.SetActive(false);
                buttonOk.SetActive(true);
            }
            buttonLast.SetActive(true);
        }
    }
}