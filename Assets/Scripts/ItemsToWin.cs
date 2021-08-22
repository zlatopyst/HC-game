using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsToWin : MonoBehaviour
{
    public static int count;
    [SerializeField] private int newCount;
    private GameObject Winwin;
    private GameObject[] stars;
    
    void Start()
    {
        count = newCount;
        Buttons.Button += newStart;
        Buttons.Button2 += newStart;
        Winwin = ItemsToFind.Winwin;
    }

    void Update()
    {
        if (count == 0) 
        {

            Winwin.SetActive(true);
            stars = new GameObject[3];
            for (int i = 0; i <= 2; i++)
            {
                stars[i] = Winwin.transform.GetChild(i + 3).gameObject;
            }
            if (Timer.stars == 3)
            {
                for (int i = 0; i < 3; i++)
                    stars[i].SetActive(true);
            }
            else if (Timer.stars == 2)
            {
                for (int i = 0; i < 2; i++)
                    stars[i].SetActive(true);
            }
            else if (Timer.stars == 1)
            {
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
        count = newCount;
        if (Winwin.activeInHierarchy)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (stars[i].activeSelf == true)
                    stars[i].SetActive(false);
            }
            Winwin.SetActive(false);
        }

    }
}
