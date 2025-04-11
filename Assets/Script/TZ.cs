using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TZ : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Piying;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButtonOnclick()
    {

        SceneManager.LoadScene("First");
    

    }
    public void PlayButtonOnClick()
    {
        Piying.Play();
    
    }
    public void PauseButtonOnClick()
    {
        Piying.Pause();

    }
    public void StopButtonOnClick()
    {
        Piying.Stop();
    
    }

   
}
