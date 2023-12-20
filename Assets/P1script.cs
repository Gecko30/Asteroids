using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1script : MonoBehaviour
{   
    public Rigidbody2D rigidBody;
    public float rocketStrength;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAngle=0.0f;
        //myTime = myTime + Time.deltaTime;
        //replace the KeyCodes with whatever buttons on the thing

        /*
                if(rigidBody.transform.eulerAngles.z<=360f )
                {
                    rotationAngle = rigidBody.transform.eulerAngles.z;
                }
                else
                {
                   rotationAngle = rigidBody.transform.eulerAngles.z-360f;
                }
        */
        rotationAngle = rigidBody.transform.eulerAngles.z;
        print("angle= "+ rotationAngle + " x value= "+-Mathf.Sin(rotationAngle)+ " y value = " + -Mathf.Cos(rotationAngle));
        if (Input.GetKey("up") == true)
        {
            //rigidBody.rotation 
            rigidBody.transform.Rotate(0, 0, rotationSpeed);
        }
        if(Input.GetKey("right") == true) {

            rigidBody.velocity = new Vector2(-Mathf.Sin(rotationAngle)*rocketStrength,-Mathf.Cos(rotationAngle) * rocketStrength);
        }
        if(Input.GetKey("left") == true) {
            rigidBody.velocity = new Vector2(Mathf.Sin(rotationAngle) * rocketStrength, Mathf.Cos(rotationAngle) * rocketStrength);
        }
        if(Input.GetKey("down") == true) {
            rigidBody.transform.Rotate(0,0,-rotationSpeed);
        }        
    }

}
