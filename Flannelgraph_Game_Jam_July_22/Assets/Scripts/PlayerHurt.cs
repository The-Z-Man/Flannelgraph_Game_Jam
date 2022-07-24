using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private PlayerCheckpoint pc;
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerCheckpoint>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Hazard")
        {
            transform.position = pc.GetCheckpoint().transform.position;
        }
    }
}
