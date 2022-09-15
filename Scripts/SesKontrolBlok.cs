using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrolBlok : MonoBehaviour
{
    public AudioSource ses_kontrol1;

    void Start()
    {

        ses_kontrol1 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            ses_kontrol1.mute = false;


        }
        else
        {
            ses_kontrol1.mute = true;

        }
    }
}
