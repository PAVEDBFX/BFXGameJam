using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheWorld : MonoBehaviour
{

    public float worldRadius;

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - Vector3.zero).magnitude > worldRadius)
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
}
