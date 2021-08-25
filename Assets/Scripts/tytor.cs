using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tytor : MonoBehaviour
{
    private float time = 3;
    private Text schet;
    private bool ready;
    [SerializeField] private GameObject UI;
    private Animator text_animator;

    void Start()
    {
        text_animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        ready = false;
        schet = transform.GetChild(1).gameObject.GetComponent<Text>();
    }

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

        }
    }
    private void Otschet()
    {
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
