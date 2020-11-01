using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FinRotate : MonoBehaviour
{
 

    // Start is called before the first frame update
 
    void Update()
    {
        Finmove();
        Finreturn();
    }
    // Update is called once per frame
    void Finmove()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0.0f, -20.0f, 0.0f);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0.0f, 20.0f, 0.0f);
        }
    }

    void Finreturn()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Rotate(0.0f, 20.0f, 0.0f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Rotate(0.0f, -20.0f, 0.0f);
        }
    }

    }
