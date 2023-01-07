using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CollisionLevelTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.attachedRigidbody.tag == "Player")
        {
            // Find Object w/ Level Switcher
            LevelSwitcher switcher = GameObject.Find("Level Switcher").GetComponent<LevelSwitcher>();

            // Call Next Level Function
            switcher.NextLevel();

            // Debug Print Statement
            Debug.Log("Collision Successfully Read");
        }
    }
}
