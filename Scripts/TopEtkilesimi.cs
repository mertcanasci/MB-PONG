using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopEtkilesimi : MonoBehaviour
{

    public GameObject ReklamPanel,IsimalmaPanel;
    public static Rigidbody2D top;
    public float yatayHiz, dikeyHiz;
    public float speed = 7;
    private int topVplayerEtkilesimi = 2;
    public static int panelsayi = 1;

    private void Start()
    {
        top = GetComponent<Rigidbody2D>();
        top.velocity = new Vector2(Random.Range(-yatayHiz, yatayHiz), top.velocity.y);
        //GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                   float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return ((ballPos.x - racketPos.x) * 2) / racketHeight;
    }



    public void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Player")
        {
            top.gravityScale = 0f;
            topVplayerEtkilesimi = 2;
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                temas.transform.position,
                                temas.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

            if (temas.gameObject.tag == "SolDuvar")
        {
            topVplayerEtkilesimi--;
            if (topVplayerEtkilesimi <= 0)
            {
                top.gravityScale = 0.1f;
                //GetComponent<ConstantForce>().force = new Vector3(0, -25.0f, 0);
            }

            top.velocity = new Vector2(yatayHiz, top.velocity.y);
        }
        if (temas.gameObject.tag == "SagDuvar")
        {
            topVplayerEtkilesimi--;
            if (topVplayerEtkilesimi <= 0)
            {
                top.gravityScale = 0.1f;
                //GetComponent<ConstantForce>().force = new Vector3(0, -25.0f, 0);
            }

            top.velocity = new Vector2(-yatayHiz, top.velocity.y);
            
        }
        if (temas.gameObject.tag == "UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -dikeyHiz);
        }
        if (temas.gameObject.tag == "KupOne")
        {
            top.velocity = new Vector2(top.velocity.x, top.velocity.y);
        }
        if (temas.gameObject.tag == "KupTwo")
        {
            top.velocity = new Vector2(top.velocity.x, top.velocity.y);
        }
        if (temas.gameObject.tag == "KupZero")
        {
            top.velocity = new Vector2(top.velocity.x, top.velocity.y);
        }
      

        if (temas.gameObject.tag == "AltDuvar")
        {

            if (panelsayi == 1)
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
