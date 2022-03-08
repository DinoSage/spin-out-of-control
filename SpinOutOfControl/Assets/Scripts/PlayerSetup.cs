using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour, IFreezable
{

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Rigid Body Setup
        this.rigidBody = GetComponent<Rigidbody2D>();

        // Freeze Rotation
        //rigidBody.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckFreeze()
    {
        rigidBody.freezeRotation = true;
    }

}
