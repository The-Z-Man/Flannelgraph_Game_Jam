using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHurt : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().Health -= 50;
            Debug.Log("SPIKES!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
