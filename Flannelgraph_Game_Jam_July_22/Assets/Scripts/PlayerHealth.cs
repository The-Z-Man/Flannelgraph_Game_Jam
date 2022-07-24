using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;

    private PlayerCheckpoint pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerCheckpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            transform.position = pc.GetCheckpoint().transform.position;
            Health = 100;
        }
        
    }

}
