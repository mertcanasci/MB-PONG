using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses : MonoBehaviour
{
    public GameObject ses_acik, ses_kapali;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("sesDurum") == 1)
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
        }
        else
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
        }
    }

    public void ses_durum (string durum)
    {
        if(durum == "acik") //ses kapama
        {
            ses_acik.SetActive(false);
            ses_kapali.SetActive(true);
            PlayerPrefs.SetInt("sesDurum", 0);
        }
        else if (durum == "kapali") //ses açma
        {
            ses_acik.SetActive(true);
            ses_kapali.SetActive(false);
            PlayerPrefs.SetInt("sesDurum", 1);
        }
    }
}
