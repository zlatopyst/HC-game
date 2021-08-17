using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tytor : MonoBehaviour
{
    private float time = 3;
    private Text schet;
    private bool ready;
    public GameObject UI;
    private Animator text_animator;
    // Start is called before the first frame update
    void Start()
    {
        text_animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        ready = false;
        schet = transform.GetChild(1).gameObject.GetComponent<Text>();
    }
    // Update is called once per frame
    public void OnClicked()
    {
        ready = true;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        text_animator.SetBool("Bool", true);
    }
    void Update()
    {
        if (time > -1 & ready != false)
        {
            time -= Time.deltaTime;
            Otschet();
            //print(stars);
        }
    }
    private void Otschet()
    {
        Debug.Log(time);
        if (time > 2)
        {
            schet.text = "3";
        }
        else if (time > 1)
        {
            schet.text = "2";
        }
        else if (time > 0)
        {
            schet.text = "1";
        }
        else if (time > -1)
        {
            schet.text = "START";
        }
        else if (time > (-1.2))
        {
            text_animator.SetBool("Bool", false);
            this.gameObject.SetActive(false);
            UI.SetActive(true);
        }
    }
}
