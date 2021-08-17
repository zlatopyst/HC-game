using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsToWin : MonoBehaviour
{
    Text text;
    public static int count;
    public int x = 1;
    public GameObject Winwin;
    private GameObject Child;
    private GameObject[] stars;
    
    // Start is called before the first frame update
    void Start()
    {
        count = x;
        Buttons.Button += newStart;
        Buttons.Button2 += newStart;
        Winwin = ItemsToFind.Winwin;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0) 
        {

            //Child = Winwin.transform.GetChild(2).gameObject;
            //text = Child.GetComponent<Text>();
            //text.text = ("Stars : " + timer.stars.ToString());
            Winwin.SetActive(true);
            stars = new GameObject[3];
            for (int i = 0; i <= 2; i++)
            {
                stars[i] = Winwin.transform.GetChild(i + 3).gameObject;
            }
            //Debug.Log(timer.stars);
            if (timer.stars == 3)
            {
               // Debug.Log("1");
                for (int i = 0; i < 3; i++)
                    stars[i].SetActive(true);
            }
            else if (timer.stars == 2)
            {
                //Debug.Log("2");
                for (int i = 0; i < 2; i++)
                    stars[i].SetActive(true);
            }
            else if (timer.stars == 1)
            {
                //Debug.Log("3");
                for (int i = 0; i < 1; i++)
                    stars[i].SetActive(true);
            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            Podchet();
        }
    }
    public void Podchet()
    {
        if (count > 0)
        {
            count--;
        }
    }
    private void newStart()
    {
        count = x;
        for (int i = 0; i <= 2; i++)
        {
           // if (stars[i].activeSelf == true)
           // stars[i].SetActive(false);
        }
        Winwin.SetActive(false);

    }
}
