using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float lerpDuration = 1;
    public const float gravity = -9.81f;
    public float endValueMagnitude = 90f;
    int rotateDirection = 1; // -1 for Right, 1 for Left, 0 for Not Rotating

    float timeElapsed;
    float startValue = 0;
    float valueToLerp;

    bool rotating = false;
    float prerotationZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) ^ Input.GetKeyDown(KeyCode.LeftArrow)) && !rotating)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rotateDirection = -1;
            }
            else
            {
                rotateDirection = 1;
            }

            // Shut of Gravity
            Rigidbody2D[] bodies = GetComponentsInChildren<Rigidbody2D>();
            foreach(Rigidbody2D body in bodies)
            {
                body.simulated = false;
            }

            timeElapsed = 0f;
            rotating = true;
            Debug.Log(transform.rotation.eulerAngles.z);
            prerotationZ = transform.eulerAngles.z;
        }

        if (rotating)
        {
            rotationLerp();
        }
    }

    // Method for Lerp Rotation
    void rotationLerp()
    {
        if (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValueMagnitude, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else // Runs When Lerp is About to End
        {
            valueToLerp = endValueMagnitude;
            rotating = false;
            
            //Reenable Gravity
            Rigidbody2D[] bodies = GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D body in bodies)
            {
                body.velocity = Vector2.zero;
                body.simulated = true;
            }
        }

        transform.rotation = Quaternion.AngleAxis(prerotationZ + (rotateDirection * valueToLerp), Vector3.forward);
    }
}
