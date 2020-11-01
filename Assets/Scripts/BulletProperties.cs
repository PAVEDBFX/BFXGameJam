using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{

    private float vx0;
    private float vy0;
    private float dx;
    private float dy;

    private int maxLife = 8;

    private float gravity = - 9.8f;
    private float g;
    private Vector3 target;
    private Vector3 start;

    private int damage;

    private Vector3 directionOnGround;

    private bool setup = false;

    // You can use this function to fire tbe bullet, it will not work if you haven't done the setup
    public void Fire ()
    {
        if (!setup) return;
        g = gravity;
        start = transform.position;
        dx = Mathf.Sqrt(Mathf.Pow(target.z - transform.position.z, 2) + Mathf.Pow(target.x - transform.position.x, 2));
        dy = target.y - transform.position.y;
        float totalTime = dx / vx0;
        vy0 = (dy - (g * totalTime * totalTime / 2)) / totalTime;
        directionOnGround = new Vector3(target.x, 0, target.z) - new Vector3(start.x, 0, start.z);
        directionOnGround = directionOnGround.normalized;
        
        Vector3 velocity = directionOnGround * vx0 + Vector3.up * vy0;

        GetComponent<Rigidbody>().velocity = velocity;

    }

    public void Update()
    {
        transform.LookAt(transform.position - GetComponent<Rigidbody>().velocity*10);
    }

    // You can use one of these three functions to set up the bullet
    public void SetBulletProperties (float horizontalVelocity, GameObject myTarget, int myDamage)
    {
        vx0 = horizontalVelocity;
        target = myTarget.transform.position;
        damage = myDamage;
        setup = true;
    }

    public void SetBulletProperties(float horizontalVelocity, Transform myTarget, int myDamage)
    {
        vx0 = horizontalVelocity;
        target = myTarget.position;
        damage = myDamage;
        setup = true;
    }

    public void SetBulletProperties(float horizontalVelocity, Vector3 myTarget, int myDamage)
    {
        vx0 = horizontalVelocity;
        target = myTarget;
        damage = myDamage;
        setup = true;
    }

    // Use this function to access the damage value of the bullet
    public int Damage()
    {
        return damage;
    }

    void FixedUpdate ()
    {
        // Destroy the bullet if it goes below the water surface
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator timerToDie ()
    {
        yield return new WaitForSeconds(maxLife);
        Destroy(gameObject);
    }
}
