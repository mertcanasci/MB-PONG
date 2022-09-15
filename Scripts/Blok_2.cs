using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Blok_2 : MonoBehaviour
{
    public float hiz;
    float randx;
    public GameObject ReklamPanel, IsimalmaPanel;
    public AudioSource BlokSesi;
    float hiz2 = 1.3f;
    private SpriteRenderer ressam;
    public Sprite Sari, Kirmizi, Mavi, Yesil;
    
    void Start()
    {
        ressam = GetComponent<SpriteRenderer>();
        // Renkver();

    }

    void Update()
    {
       /* if (Kazandik.Scoredegeri >= 100)
        {
            hiz = hiz2;

        }*/


        transform.position += Vector3.down * hiz * Time.deltaTime;
        randx = Random.Range(0, 2.5f);


    }





    public void OnCollisionEnter2D(Collision2D temas)
    {

        if (temas.gameObject.tag == "Top")
        {
            this.gameObject.transform.position = new Vector3(randx, 6, 0);
            Kazandik.puandegeri += 10;
            //Renkver();
            BlokSesi.Play();
            

            int rastgele = Random.Range(1, 5);
            switch (rastgele)
            {
                case 1:
                    ressam.sprite = Sari;
                    break;
                case 2:
                    ressam.sprite = Kirmizi;
                    break;
                case 3:
                    ressam.sprite = Mavi;
                    break;
                case 4:
                    ressam.sprite = Yesil;
                    break;
            }
        }

        if (temas.gameObject.tag == "KupOne")
        {
            this.gameObject.transform.position = new Vector3(randx, 7.6f, 0);
        }
        if (temas.gameObject.tag == "KupZero")
        {
            this.gameObject.transform.position = new Vector3(randx, 7.6f, 0);
        }

        if (temas.gameObject.tag == "AltDuvar")
        {

            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Player.can--;

            if (Player.can >= 1)
            {
                this.gameObject.transform.position = new Vector3(randx, 7.6f, 0);
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
