using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float speed = 50.0f;
    public GameObject prefab1;
    void Update()
    {
     if(Input.GetKey(KeyCode.D) && transform.position.x < 120)
     {
         transform.position += new Vector3(speed * Time.deltaTime,0,0);
     }
     else if(Input.GetKey(KeyCode.A) && transform.position.x > 0)
     {
         transform.position -= new Vector3(speed * Time.deltaTime,0,0);
     }
    }
}