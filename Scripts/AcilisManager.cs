using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using itfriedl.Highscores;

public class AcilisManager : MonoBehaviour
{

    public GameObject _RakningPanel;
    public HighscoreManager hm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RankingPanelOpen()
    {
        _RakningPanel.SetActive(true);
        
        hm.GetScoresOnline("http://gamerowmobile.com/highscore/highscoreout.php");
        // we put in online scores
        
    }
    public void RankingPanelClose()
    {
        _RakningPanel.SetActive(false);
        

    }


}
