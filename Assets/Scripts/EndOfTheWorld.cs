﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheWorld : MonoBehaviour
{

    public Transform firstCorner;
    public Transform oppositeCorner;


    // Update is called once per frame
    void Update()
    {
        if (isOut())
        {
            switch(GetComponent<PointsAndUpgrades>().getShip())
            {
                case 0:
                    // end scene for ship 1
                    // load scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

                    break;
                case 1:
                    // end scene for ship 2
                    // load scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);

                    break;
                case 2:
                    // end scene for ship 3
                    // load scene
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);

                    break;
            }
        }        
    }


    bool isOut()
    {
        if (transform.position.x > Mathf.Max(firstCorner.transform.position.x, oppositeCorner.transform.position.x)) return true;
        if (transform.position.x < Mathf.Min(firstCorner.transform.position.x, oppositeCorner.transform.position.x)) return true;
        if (transform.position.z > Mathf.Max(firstCorner.transform.position.z, oppositeCorner.transform.position.z)) return true;
        if (transform.position.z < Mathf.Min(firstCorner.transform.position.z, oppositeCorner.transform.position.z)) return true;
        return false;
    }
}
