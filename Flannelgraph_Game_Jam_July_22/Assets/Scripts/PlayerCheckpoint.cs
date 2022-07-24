using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject currentCheckpoint;
    public GameObject GetCheckpoint() => currentCheckpoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CheckPoint")
        {
            currentCheckpoint = collision.gameObject;
            Debug.Log("New Checkpoint!");
        }
    }
}
