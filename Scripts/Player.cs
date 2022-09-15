using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    //public InputField isim;
    public TMP_InputField isim;
    public static string isimRanke;
    public static float can;
    public GameObject IsimalmaPanel,ReklamPanel;
    
    void Start()
    {
        can = 3;
    }


    void Update()
    {
        FinalScore.puankayit = Kazandik.puandegeri;

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            mousePos.y = -4.76f;
            transform.position = mousePos;

        }
    }

    public void nooAd()
    {
        //SceneManager.LoadScene(2);


        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // no internet back to begin...
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            Kazandik.puandegeri = 0;
        }
        else
        {
            //if internet
            ReklamPanel.SetActive(false);
            IsimalmaPanel.SetActive(true);
        }
    }

    public void SubmitButton()
    {

        isimRanke = isim.text;      //alýnan ismi finalscore.cs gönder ve ranking tablosuna yaz

        //hm.InsertScore(isimRanke, Kazandik.puandegeri);
        SceneManager.LoadScene(2); // ve ranking aç
        


    }

}
