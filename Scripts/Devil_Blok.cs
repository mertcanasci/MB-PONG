using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Devil_Blok : MonoBehaviour
{
    public float hiz;
    public AudioSource BlokSesi;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * hiz * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {


        if (temas.gameObject.tag == "Top")
        {

            Kazandik.puandegeri += 150;
            Player.can++;
            //Renkver();
            BlokSesi.Play();
            Destroy(gameObject);

        }

        if (temas.gameObject.tag == "AltDuvar")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Player.can++;

            if (Player.can >= 1)
            {
                Kazandik.puandegeri -= 300;
                Destroy(gameObject);
            }

            if (Player.can == 0)
            {
                Kazandik.puandegeri -= 300;
                Destroy(gameObject);
            }
        }


    }
}
