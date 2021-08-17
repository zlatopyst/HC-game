using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public GameObject Lose;
    public Slider mySlider;
    public Slider mySliderBG;
    public float timeLeft = 60;
    private float gameTime;
    private float i;
    public static int stars;
    

    // Start is called before the first frame update
    void Start()
    {
        //Lose = ItemsToFind.Lose;
        mySlider.minValue = 0;
        mySlider.maxValue = timeLeft;
        mySliderBG.minValue = 0;
        mySliderBG.maxValue = timeLeft;
        i = timeLeft;
        Buttons.Button += newStart;
        Buttons.Button2 += newStart2;
    }

    // Update is called once per frame
    void Update()
    {

        if (ItemsToWin.count == 0)
            mySlider.gameObject.SetActive(false);

        if (timeLeft > 0 & ItemsToWin.count != 0)
        {
            timeLeft -= Time.deltaTime * enemy.x;
            mySlider.value = timeLeft;
            mySliderBG.value = timeLeft;
            Stars();
            //print(stars);
        }
        if (timeLeft <= 0)
        {
            Lose.SetActive(true);
            mySlider.gameObject.SetActive(false);
            mySliderBG.gameObject.SetActive(false);
        }

    }
    public void Stars()
    {

            //Debug.Log(stars);
            if (timeLeft > (i / 3 * 2))
            {
                stars = 3;
            }
            else if (timeLeft > (i / 3))
            {
                stars = 2;
            }
            else if (timeLeft < (i / 3) & timeLeft > 0)
            {
                stars = 1;
            }
            else { stars = 0;  }
    }
    private void newStart()
    {
        timeLeft = i;
        Lose.SetActive(false);
        mySlider.gameObject.SetActive(true);
        mySliderBG.gameObject.SetActive(true);
    }
    private void newStart2()
    {
        timeLeft = i;
        mySlider.gameObject.SetActive(true);
        mySliderBG.gameObject.SetActive(true);
    }
}
