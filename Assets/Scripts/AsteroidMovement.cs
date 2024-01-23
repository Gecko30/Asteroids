using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public int timer;
    public Vector3 asteroidVector;
    public float moveSpeed;
    public bool flipper = true;

    public float clock = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;


        if (clock > timer)
        {
            flipper = !flipper;
            clock = 0;

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
