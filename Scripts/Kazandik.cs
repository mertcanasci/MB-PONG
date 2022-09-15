using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kazandik : MonoBehaviour
{
    public TextMeshProUGUI KazandikYazisi;
    public static int puandegeri=0;
    public TextMeshProUGUI PuanYazisi;
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        PuanYazisi.text = "" + puandegeri;
    }
}
