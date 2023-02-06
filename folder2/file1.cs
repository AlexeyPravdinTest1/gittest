using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public float curHealth;
    public AudioClip barrelSound;
    public AudioSource sndSrc; 
    // Start is called before the first frame update
    void Start()
    {
        if (curHealth != 200f) curHealth = 100f;
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
       float v = collision.relativeVelocity.magnitude;
       if (v<7) v=0;
       float m = collision.gameObject.GetComponent<Rigidbody2D>().mass;
       float k = 1f;
       if (collision.collider.tag == "Cannonball") k = 8f;
       if (collision.collider.tag == "Shotgunball") k = 3.5f;
       if (collision.collider.tag == "BulletRifle") k = 50f;
       float dmg = 0.1f * k * Mathf.Sqrt(m * v);
       if (dmg > 1f)
       {
            curHealth -= dmg;
       }
       if (curHealth < 0)
        {
            sndSrc.clip = barrelSound;
            sndSrc.Play();
            transform.DetachChildren();
            Destroy(gameObject, 0f);
        }
    }
}
