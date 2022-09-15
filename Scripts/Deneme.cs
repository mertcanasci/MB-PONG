using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Deneme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartButton()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Kazandik.puandegeri = 0;
        TopEtkilesimi.panelsayi = 1;
    }

    public void StartButton2()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
        Kazandik.puandegeri = 0;
    }
}
