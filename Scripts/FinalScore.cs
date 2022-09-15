using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using itfriedl.Highscores;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI KazandikYazisi;
    public static int puankayit;
    public HighscoreManager hm;
    void Start()
    {

        puankayit = Kazandik.puandegeri;
        KazandikYazisi.text = "Score : " + Kazandik.puandegeri +  "\n GET HIGHER ?";
        hm.InsertScore(Player.isimRanke, Kazandik.puandegeri);
    }

    // Update is called once per frame
    void Update()
    {
        puankayit = Kazandik.puandegeri;

    }
}
