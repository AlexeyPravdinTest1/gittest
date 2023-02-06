using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    private SpriteRenderer sp;
    public AudioSource a;
    public AudioClip[] c;
    private bool flag = true;

    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
    }

    void fade()
    {
        Color tmp = sp.color;
        tmp.a -= 0.02f;
        if (tmp.a>0.05f) 
        {
            sp.color = tmp;
            Invoke("fade", 0.05f);
        }
        else Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 7f);
         if (collision.collider.tag == "Pirateship") 
         {
            GameObject emptyObject = new GameObject();
            Destroy(emptyObject, 5f);
            Invoke("fade", 2f);
            emptyObject.transform.SetParent(collision.gameObject.transform, true);
            this.transform.SetParent(emptyObject.transform, true);
            if (flag)
            {
                a.clip = c[Random.Range(0,c.Length)];
                a.Play();
            }
            flag = false;
         }
         else if (collision.collider.tag == "Pirateship") flag = false;
    }
}
