using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    public LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)               
    {
        //put pump functionality in each of the cases
        if (other.gameObject.CompareTag("P1")&& gameObject.tag.Equals("P2Bullet"))
        {
            //when P2 hits P1
            Destroy(gameObject);
            Destroy(other.gameObject);
            logic.p2Wins();
        }
        if(other.gameObject.CompareTag("P2") && gameObject.tag.Equals("P1Bullet"))
        {
            //when P1 hits P2
            Destroy(gameObject);
            Destroy(other.gameObject);
            logic.p1Wins();
        }
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
   
}
