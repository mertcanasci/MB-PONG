using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Blok_1 : MonoBehaviour
{
    public float hiz;
    float randx;
    public GameObject ReklamPanel, IsimalmaPanel;
    public AudioSource BlokSesi;
   // float hiz2 = 1.3f;
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
            hiz = hiz2;  AÇILACAK

        }*/


        transform.position += Vector3.down * hiz * Time.deltaTime;
        randx = Random.Range(-2f, 0);


    }





    public void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "KupZero")
        {
            this.gameObject.transform.position = new Vector3(randx, 7.5f, 0);
        }

        if (temas.gameObject.tag == "KupTwo")
        {
            this.gameObject.transform.position = new Vector3(randx, 7.5f, 0);
        }

        if (temas.gameObject.tag == "AltDuvar")
        {

            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Player.can--;

           if (Player.can >= 1)
            {
                this.gameObject.transform.position = new Vector3(randx, 7.5f, 0);
            }
            if (Player.can == 0)
            {
                //Time.timeScale = 0;
                //SceneManager.LoadScene(2);

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

        if (temas.gameObject.tag == "Top")
        {
            this.gameObject.transform.position = new Vector3(randx, 6, 0);
            Kazandik.puandegeri += 10; 
            //Renkver();
            BlokSesi.Play();
            //Destroy(this.gameObject);

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

        
    }
}