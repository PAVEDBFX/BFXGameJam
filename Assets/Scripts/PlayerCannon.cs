using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour
{
    public Camera cam;
    public Transform idleTarget;
    public float rotationSpeed;
    public GameObject bullet;
    public GameObject cannon;
    public Transform bulletSpawnPosition;
    public float timeToComeBack;
    public GameObject ship;

    private Quaternion baseLookRotation;
    private Quaternion cannonLookRotation;
    private Vector3 direction;
    private Vector3 baseDirection;
    private Vector3 cannonDirection;

    private bool idlePosition = true;
    private bool shootingPosition = false;

    // Update is called once per frame
    void Update()
    {

        if (idlePosition)
        {
            direction = idleTarget.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 objectHit = hit.point;
                direction = objectHit;
                idlePosition = false;

                baseDirection = new Vector3(direction.x, transform.position.y, direction.z);
                cannonDirection = direction;


                cannon.transform.LookAt(cannonDirection);
            }
        }

 //       direction = direction.normalized;
        cannonDirection = direction;
        cannon.transform.LookAt(cannonDirection);

       // transform.LookAt(new Vector3(direction.x, transform.position.y, direction.z));
        // transform.rotation = transform.rotation * ship.transform.rotation;
    }


    
}
