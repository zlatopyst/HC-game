using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject Lose;
    [SerializeField] private Slider mySlider;
    [SerializeField] private Slider mySliderBG;
    [SerializeField] private float timeLeft;
    private float i;
    public static int stars;
    


    void Start()
    {

        mySlider.minValue = 0;
        mySlider.maxValue = timeLeft;
        mySliderBG.minValue = 0;
        mySliderBG.maxValue = timeLeft;
        i = timeLeft;
        Buttons.Button += Restart;
        Buttons.Button2 += newStart;
    }

    void Update()
    {

        if (ItemsToWin.count == 0)
            mySlider.gameObject.SetActive(false);

        if (timeLeft > 0 & ItemsToWin.count != 0)
        {
            timeLeft -= Time.deltaTime * Enemy.x;
            mySlider.value = timeLeft;
            mySliderBG.value = timeLeft;
            Stars();
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
    private void Restart()
    {
        timeLeft = i;
        Lose.SetActive(false);
        mySlider.gameObject.SetActive(true);
        mySliderBG.gameObject.SetActive(true);
    }
    private void newStart()
    {
        timeLeft = i;
        mySlider.gameObject.SetActive(true);
        mySliderBG.gameObject.SetActive(true);
    }
}
