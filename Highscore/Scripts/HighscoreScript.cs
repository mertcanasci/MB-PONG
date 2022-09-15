using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{
    public TextMeshProUGUI uiRank;
    public TextMeshProUGUI uiScore;
    public TextMeshProUGUI uiName;
    //public TextMeshProUGUI uiMove;
    //public TextMeshProUGUI uiTime;
    public TextMeshProUGUI uiDate;

    public void SetScore(string strRank, string strScore, string strName)
    {
        uiRank.text = strRank;
        uiScore.text = strScore;
        uiName.text = strName;
        /*if (strTime.Length > 2)
        {
            strTime = strTime.Insert(strTime.Length - 2, ".");
        }
        uiTime.text = "time" + " " + strTime + " s";
        uiMove.text = "moves" + " " + strMoves;
        */
        //uiDate.text =" " + strDate;
    }
}
