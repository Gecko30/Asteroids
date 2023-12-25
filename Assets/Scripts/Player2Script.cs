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
        //myTime = myTime + Time.deltaTime;
        //replace the KeyCodes with whatever buttons on the thing


        rotationAngle = rigidBody.transform.eulerAngles.z;
        //convert to radians
        rotationAngle = rotationAngle * Mathf.PI / 180;


        if (Input.GetKey("d") == true)
        {
            rigidBody.transform.Rotate(0, 0, rotationSpeed);
        }
        if (Input.GetKey("s") == true)
        {
            orientationVector = (new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }


        }
        orientationVector = (new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
        if (Input.GetKey("w") == true)
        {
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }

        }
        if (Input.GetKey("a") == true)
        {
            rigidBody.transform.Rotate(0, 0, -rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            orientationVector3 = orientationVector;
            bms.bulletVector = orientationVector3;
            Instantiate(bulletSpawner, rigidBody.position + orientationVector * 45, transform.rotation);
            bulletSpawner.tag = "P2";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            Destroy(other.gameObject);
        }
    }
}
