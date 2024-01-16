using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LogicManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public bool p1Alive;
    public bool p2Alive;
    
    public void restartGame()
    {
        int mapchooser = Random.Range(1,9); //have this be a random number
        //have a number generator and create multiple scenes
        string mapname = "Map"+mapchooser.ToString();
        SceneManager.LoadSceneAsync(mapname);
        p1Alive = true;
        p2Alive = true;


    }

    private void Start()
    {
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }

    void Update()
    {
                if (Input.GetKeyDown(KeyCode.Space))
                {
            restartGame();
        }
    }

    public void p1Wins()
    {
        P1.SetActive(true);
        p2Alive = false;
        if (p1Alive == false) 
        {
            P1.SetActive (false);
            P2.SetActive (false);
            P3.SetActive (true);


        }

    }

    public void p2Wins()
    {
        P2.SetActive(true);
        p1Alive = false;
        if (p2Alive == false) 
        {
            P1.SetActive (false);
            P2.SetActive(false);
            P3.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.P)){
            restartGame();
        }
    }
    
}
