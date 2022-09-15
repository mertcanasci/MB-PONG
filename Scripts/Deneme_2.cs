using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Deneme_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartButton()
    {
        TopEtkilesimi.panelsayi = 1;
        SceneManager.LoadScene(1);

    }
}
