using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public int timer;
    public Vector3 asteroidVector;
    public float moveSpeed;
    public bool flipper = false;
    public bool flipped = true;
    public float clock = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;

        
        if ((Mathf.Round(clock) % timer ==0))
        {
            if(flipped)
            {
                flipped = false;
                flipper = true;
            }
        }
        else
        {
            if (flipper)
            {
                flipped = true;
                flipper = false;
            }
        }

        if (flipper)
        {
            transform.position += (asteroidVector * moveSpeed) * Time.deltaTime;
        }
        else
        {
            transform.position -= (asteroidVector * moveSpeed) * Time.deltaTime;
        }
    }
}
