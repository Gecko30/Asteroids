using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Script : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float rocketStrength;
    public float rotationSpeed;
    public float maxRotationSpeed;
    public GameObject bulletSpawner;
    public float offset;
    public GameObject logicManager;
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
        //replace the KeyCodes with whatever buttons on the thing


        rotationAngle = rigidBody.transform.eulerAngles.z;
        //convert to radians
        rotationAngle = rotationAngle * Mathf.PI / 180;


        if (Input.GetKey("l") == true | Gamepad.all[0].rightStick.right.isPressed)
        {
            rigidBody.transform.Rotate(0, 0, rotationSpeed);
        }
        if (Input.GetKey("k") == true | Gamepad.all[0].rightStick.down.isPressed)
        {
            orientationVector = -(new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }


        }
        orientationVector = (new Vector2(Mathf.Sin(rotationAngle), Mathf.Cos(rotationAngle))).normalized * -rocketStrength;
        if (Input.GetKey("i") == true | Gamepad.all[0].rightStick.up.isPressed )
        {
            if (rigidBody.velocity.magnitude < maxRotationSpeed)
            {

                rigidBody.velocity = (rigidBody.velocity) + orientationVector;
            }

        }

        if (Input.GetKey("j") == true || Gamepad.all[0].rightStick.left.isPressed)
        {
            rigidBody.transform.Rotate(0, 0, -rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.O) || Gamepad.all[0].rightShoulder.wasPressedThisFrame)
        {
            orientationVector3 = orientationVector;
            bms.bulletVector = orientationVector3;
            Instantiate(bulletSpawner, rigidBody.position + orientationVector * offset, transform.rotation);
            bulletSpawner.tag = "P2Bullet";
        }
    }

}
