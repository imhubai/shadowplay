using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foundSceneManager : MonoBehaviour
{
    public GameObject[] targetObj;
    public GameObject targetImg;

    private int objCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targetObj.Length; i++)
        {
            if (targetObj[i].activeInHierarchy) 
            {
                objCount++;
            }
        }
        if (objCount > 5)
        {
            targetImg.SetActive(true);
        }
        else 
        {
            objCount = 0;
        }
    }
   
}
