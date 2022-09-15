using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Sprites;

public class Blok_3 : MonoBehaviour
{
    public float hiz;
    float randx;
    public AudioSource BlokSesi;
    float hiz2 = 1.3f;
    private SpriteRenderer resim;
    int blokSagligi=2;
    public GameObject ReklamPanel, IsimalmaPanel;
    public Sprite kirik,kendi;
    
    void Start()
    {
        resim = GetComponent<SpriteRenderer>();
        // Renkver();

    }

    void Update()
    {
       /* if (Kazandik.Scoredegeri >= 100)
        {
            hiz = hiz2;

        }*/


        transform.position += Vector3.down * hiz * Time.deltaTime;
        randx = Random.Range(-2f, 2.5f);


    }





    private void OnCollisionEnter2D(Collision2D temas)
    {


        if (temas.gameObject.tag == "Top")
        {
            blokSagligi--;
            BlokSesi.Play();

            if (blokSagligi == 1)
            {
                resim.sprite = kirik;
            }

            if (blokSagligi == 0)
            {
                
                this.gameObject.transform.position = new Vector3(randx, 23, 0);
                resim.sprite = kendi;
                blokSagligi = 2;
                Kazandik.puandegeri += 20;
                Player.can++;
              //Renkver();
               BlokSesi.Play();
               
            }


        }

        

        if (temas.gameObject.tag == "AltDuvar")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Player.can--;

            if (Player.can >= 1)
            {
                
                this.gameObject.transform.position = new Vector3(randx, 23, 0);
                resim.sprite = kendi;
                blokSagligi = 2;
            }

            if (Player.can == 0)
            {
                if (TopEtkilesimi.panelsayi == 1)
                {

                    Time.timeScale = 0;
                    ReklamPanel.SetActive(true);

                    //SceneManager.LoadScene(2);
                }
                else
                {
                    Time.timeScale = 0;
                    IsimalmaPanel.SetActive(true);
                    //SceneManager.LoadScene(2);
                }
            }
        }

    }
}
