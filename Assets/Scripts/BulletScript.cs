using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rigidBody;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float shipAngle = 0.0f;
        shipAngle = player.GetComponent<Rigidbody2D>().transform.eulerAngles.z * Mathf.PI / 180;
       // print(shipAngle);
            if(Input.GetKey("right") == true) {
                rigidBody.velocity = player.transform.forward * bulletSpeed;
            //rigidBody.velocity = new Vector2(-Mathf.Sin(shipAngle)*bulletSpeed,-Mathf.Cos(shipAngle) * bulletSpeed);
             }

        
      
    }
}
