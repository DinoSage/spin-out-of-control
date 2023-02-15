using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    int direction = 0; //-1 Left, 1 Right
    [SerializeField] float rotationSpeed;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get touch details
        Vector3 touchPos = new Vector3(0, 0, 0);
        if (Input.touchCount >= 1)
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position);

        if(0 > Input.GetAxisRaw("Horizontal") || touchPos.x < 0)
        {
            direction = 1;
        } else if(0 < Input.GetAxisRaw("Horizontal") || touchPos.x > 0)
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
