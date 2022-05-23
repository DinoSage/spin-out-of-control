using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.attachedRigidbody.tag == "Player")
        {
            Debug.Log("Pipe Collide!");
        }
        else
        {
            Debug.Log("Triggered But Not PLAYER!");
        }
    }
}
