using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CannonTop : MonoBehaviour
{
    public Transform cannon;
    public float cannonspeed;
    float cannonangle;
   

    // Update is called once per frame
    void Update()
    {
        RotateCannon();

    }

    void RotateCannon()
    {
        cannonangle += Input.GetAxis("Mouse X") * cannonspeed * Time.deltaTime;
        cannonangle = Mathf.Clamp(cannonangle, -120, 120);
        cannon.localRotation = Quaternion.AngleAxis(cannonangle, Vector3.up);
    }

}

