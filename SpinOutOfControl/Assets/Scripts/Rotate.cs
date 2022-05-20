using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    int direction = 0; //-1 Left, 1 Right
    [SerializeField] float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(0 > Input.GetAxisRaw("Horizontal"))
        {
            direction = 1;
        } else if(0 < Input.GetAxisRaw("Horizontal"))
        {
            direction = -1;
        } else
        {
            direction = 0;
        }

        float zRotation = rotationSpeed * direction * Time.deltaTime;
        
        this.transform.Rotate(new Vector3(0, 0, zRotation));


    }
}
