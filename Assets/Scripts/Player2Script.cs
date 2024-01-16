using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Script : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 orientationVector;
        Vector3 orientationVector3;
        BulletMovementScript bms = bulletSpawner.GetComponent<BulletMovementScript>();
        float rotationAngle = 0.0f;
        //replace the KeyCodes with whatever buttons on the thing


        rotationAngle = rigidBody.transform.eulerAngles.z;
        //convert to radians
        rotationAngle = rotationAngle * Mathf.PI / 180;


        if (Input.GetKey("l") == true)
        {
            rigidBody.transform.Rotate(0, 0, rotationSpeed);
        }
        if (Input.GetKey("k") == true)
        {
            orientationVector = -(new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }


        }
        orientationVector = (new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
        if (Input.GetKey("i") == true)
        {
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }

        }
        if (Input.GetKey("j") == true )
        {
            rigidBody.transform.Rotate(0, 0, -rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            orientationVector3 = orientationVector;
            bms.bulletVector = orientationVector3;
            Instantiate(bulletSpawner, rigidBody.position + orientationVector * offset, transform.rotation);
            bulletSpawner.tag = "P2Bullet";
        }
    }

}
