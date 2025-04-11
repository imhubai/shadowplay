using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTrigger : MonoBehaviour
{
    public AudioClip shiquyin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D others)
    { if (others.tag == "Player")
        {
            // others.gameObject.GetComponent<LightController>().timet1 += 5;
            AudioSource.PlayClipAtPoint(shiquyin, transform.position);
            LightController.timet1 += 5;

            Destroy(gameObject);
        }
}
void Update()
        {

        }

    }
