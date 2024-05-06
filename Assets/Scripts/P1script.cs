using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P1script : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float rocketStrength;
    public float rotationSpeed;
    public float maxRotationSpeed;
    public GameObject bulletSpawner;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 orientationVector;
        Vector3 orientationVector3;
        

        BulletMovementScript bms = bulletSpawner.GetComponent<BulletMovementScript>();
        float rotationAngle = 0.0f;
        //myTime = myTime + Time.deltaTime;
        //replace the KeyCodes with whatever buttons on the thing


        rotationAngle = rigidBody.transform.eulerAngles.z;
        //convert to radians
        rotationAngle = rotationAngle * Mathf.PI / 180;

            if (Gamepad.all[0].leftStick.right.isPressed)
            {
            rigidBody.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
             }
            if (Gamepad.all[0].leftStick.up.isPressed)
            {
            orientationVector = -(new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
                {
               
                rigidBody.velocity = (rigidBody.velocity) +orientationVector;
                }
                
            }
        orientationVector = (new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
        if (Gamepad.all[0].leftStick.down.isPressed)
            {
            if (rigidBody.velocity.magnitude < maxRotationSpeed){
            
                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
                }
            }

           
        
        if (Gamepad.all[0].leftStick.left.isPressed)
        {
            rigidBody.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);

        }
        //this is to prevent spamming
        if (Gamepad.all[0].leftShoulder.wasPressedThisFrame) { 
                orientationVector3 = orientationVector;
                bms.bulletVector = orientationVector3;
                Instantiate(bulletSpawner, rigidBody.position + (orientationVector * offset), transform.rotation);
                bulletSpawner.tag = "P1Bullet";
            }
        
    }
}
