using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowTrigger : MonoBehaviour
{
    public static int Score = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
          Score++;

            Destroy(gameObject);
        }
        if (other.tag == "Ground")
        {


            Destroy(gameObject);
        }

    }
}
