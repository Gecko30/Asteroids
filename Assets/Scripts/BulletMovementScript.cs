using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 bulletVector;
    public float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (bulletVector* bulletSpeed)*Time.deltaTime;
        if(transform.position.y > 5.50 ||transform.position.y<-8.84||transform.position.x < -9.65 ||transform.position.x> 9.9)
        {
            Destroy(gameObject);
        }
    }
}
