using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon01 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fort;
    public int ID = 0;
    void Start()
    {
        fort = GameObject.Find("FortContainer");
    }

    void OnMouseDown() 
    {
        CannonScript.cannonChosen = ID;
    }
}
