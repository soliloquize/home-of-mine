using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLogic : MonoBehaviour {

    private bool isBeatable;
    public Vector4 col;

    void Awake()
    {
        col = new Vector4(1f- Random.value*0.5f, 1f- Random.value*0.5f, 1f-Random.value*0.5f, 1f);
        this.GetComponent<Renderer>().material.color = col;
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.transform.tag == "player")
        {
            
        }
    }

    
}
