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
    public float timeBetweenShots;
    public float bulletSpeed;
    public int bulletDamage;

    //variables for cannon rotation
    public Transform qcannon;
    public float cannonspeed;
    float cannonangle;

    public bool onlyYaxis;
    private bool reloaded = true;
    private bool idlePosition = true;
    private bool shootingPosition = false;

    private void Start()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        ship = GameObject.Find("Ship");
        idleTarget = GameObject.Find("IdleTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCannon();

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
                if ((direction - transform.position).magnitude > 100) return;
                idlePosition = false;

                baseDirection = new Vector3(direction.x, transform.position.y, direction.z);

                float dx = Mathf.Sqrt(Mathf.Pow(direction.z - transform.position.z, 2) + Mathf.Pow(direction.x - transform.position.x, 2));
                float dy = direction.y - transform.position.y;
                float totalTime = dx / bulletSpeed;
                float vy0 = (dy - (-9.8f * totalTime * totalTime / 2)) / totalTime;
                Vector3 directionOnGround = new Vector3(direction.x, 0, direction.z) - new Vector3(transform.position.x, 0, transform.position.z);
                directionOnGround = -directionOnGround.normalized;

                Vector3 velocity = directionOnGround * bulletSpeed;

                if (!onlyYaxis) velocity += Vector3.up * vy0;

                //cannonDirection = direction + new Vector3(0,vy0 * dx / bulletSpeed,0);

                cannonDirection = velocity;

               // cannon.transform.LookAt(cannonDirection*50);

                if (reloaded)
                {
                    GameObject myBullet = Instantiate(bullet, bulletSpawnPosition.position, Quaternion.identity);
                    myBullet.GetComponent<BulletProperties>().SetBulletProperties(bulletSpeed, direction, bulletDamage);
                    myBullet.GetComponent<BulletProperties>().Fire();
                    reloaded = false;
                    StartCoroutine(Reload());
                }
                
            }
        }

 //       direction = direction.normalized;
        //cannonDirection = direction;
        // cannon.transform.LookAt(cannonDirection);

       // transform.LookAt(new Vector3(direction.x, transform.position.y, direction.z));
        // transform.rotation = transform.rotation * ship.transform.rotation;
    }

    void RotateCannon()
    {
       
        cannonangle += Input.GetAxis("Mouse X") * cannonspeed * Time.deltaTime;
        cannonangle = Mathf.Clamp(cannonangle, -120, 120);
        qcannon.localRotation = Quaternion.AngleAxis(cannonangle, Vector3.up);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        reloaded = true;
    }

}
