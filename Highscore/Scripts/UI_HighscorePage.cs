using itfriedl.Highscores;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HighscorePage : MonoBehaviour
{
    public HighscoreManager hm;

    private void OnDisable()
    {

        hm.clearUiScores();
    }

    public void OnBuAddTest()
    {
        hm.InsertScore("Test", 123, 12, 60);
        setList(1);
    }

    public void OnBuLoad(int list)
    {
        setList(list);
    }

    public void setBuList(int list)
    {
        setList(list);
    }

    public void setList(int list, int s = 0, string n = "")
    {
        // different Scorelists...
        switch (list)
        {
            case 1: hm.GetScoresOnline("http://gamerowmobile.com/highscore/highscoreout.php"); break;
            default: hm.GetScoresOnline("http://gamerowmobile.com/highscore/highscoreout.php"); break;
        }
    }
}
