using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenUI : MonoBehaviour
{
    public GameObject PanelA;
    public  GameObject PanelAanswercorrect;
    public GameObject PanelAanswerWrong;
    public GameObject KongxiuPanel;
    private  GameObject KXWPL;
    private Button b1;
    private Button b2;
    private Button b3;
    private Button b4;
    private GameObject d;
    // Start is called before the first frame update
    void Start()
    {
        PanelA.SetActive(false);
        PanelAanswercorrect.SetActive(false);
        PanelAanswerWrong.SetActive(false);
        KongxiuPanel.SetActive(false);
        //KXWPL.SetActive(false);
        b1 = PanelA.transform.GetChild(0).GetComponent<Button>();
        b1.onClick.AddListener(closePanelAButtononclick);
        b2 = PanelA.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        b2.onClick.AddListener(ChooseWrongOnclick);
        b2 = PanelA.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        b2.onClick.AddListener(ChooseCorrectOnclick);
        b3 = PanelAanswercorrect.transform.GetChild(0).GetComponent<Button>();
        b3.onClick.AddListener(closePanelAButtononclick);
        PanelAanswercorrect.transform.GetChild(1).GetChild(0).GetComponent<Button>().onClick.AddListener(CloseChooseCorrectOnClick);
        b4 = PanelAanswerWrong.transform.GetChild(0).GetComponent<Button>();
        b4.onClick.AddListener(closePanelAButtononclick);
        PanelAanswerWrong.transform.GetChild(1).GetChild(0).GetComponent<Button>().onClick.AddListener(CloseChooseWrongOnclick);
        KongxiuPanel.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(ClosePanelKongXiuOnclick);
        KongxiuPanel.transform.GetChild(1).GetChild(0).GetComponent<Button>().onClick.AddListener(CloseChooseWrongOnclick);
    }
    /*private void OnMouseDown()
    {
        PanelA.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Boxquesiton1");
        PanelA.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("BoxAnswer1A(false)");
        PanelA.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("BoxAnswerB(true)");
        PanelA.SetActive(true);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            if (transform.gameObject.name == "BoxOpen")
            {
                loadimag(1, "box1", "A1", "B1", "C1", "W1", "shifu");
            }
            if (transform.gameObject.name == "baima")
            {
                loadimag(2, "box2", "A2", "B2", "C2", "W2", "baima");
            }
            if (transform.gameObject.name == "shidi")
            {
                loadimag(3, "box3", "A3", "B3", "C3", "W3", "shidi");
            }
            if (transform.gameObject.name == "heshui")
            {
                loadimag(4, "box4", "A4", "B4", "C4", "W4", "heshui");
                
            }
            if (transform.gameObject.name == "yaoguai")
            {
                loadimag(5, "box5", "A5", "B5", "C5", "W5", "yaoguai");
            }
            if (transform.gameObject.name == "piying")
            {
                loadimag(6, "box6", "A6", "B6", "C6", "W6", "piying");

            }
        }
    }
    void loadimag(int a,string box,string A,string B,string correct,string wrong,string tu)
    {
        KXWPL = PanelA.transform.parent.GetChild(0).GetChild(a).gameObject;
        
        KXWPL.SetActive(true);
        d = transform.gameObject;
        PanelA.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(box);
        PanelA.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(A);
        PanelA.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(B);
        PanelA.SetActive(true);
        PanelAanswercorrect.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(correct);
        PanelAanswerWrong.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(wrong);
        KongxiuPanel.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>(tu);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseCorrectOnclick()
    {
       
        PanelAanswercorrect.SetActive(true);

    }
    public void ChooseWrongOnclick()
    {
        
        PanelAanswerWrong.SetActive(true);
    }
    public void closePanelAButtononclick()
    {
        PanelA.SetActive(false);
    }
    
    public void CloseChooseWrongOnclick()
    {
        PanelAanswerWrong.SetActive(false);
    }
    public void ClosePanelKongXiuOnclick()
    {
       
        KongxiuPanel.SetActive(false);
         
        Destroy(d);
    }
    public void CloseChooseCorrectOnClick()
    {
        PanelAanswercorrect.SetActive(false);
        PanelA.SetActive(false);
        
        KongxiuPanel.SetActive(true);
        LightController.timet1 += 30;
     
       
    }
    
}


