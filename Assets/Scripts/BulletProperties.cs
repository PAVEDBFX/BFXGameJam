using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{

    public float vx0;
    private float vy0;
    private float dx;
    private float dy;

    public float gravity = -9.8f;
    private float g;
    public Vector3 target;
    private Vector3 start;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        g = gravity;
        start = transform.position;
        dx = Mathf.Sqrt(Mathf.Pow(target.z - transform.position.z, 2) + Mathf.Pow(target.x - transform.position.x, 2));
        dy = target.y - transform.position.y;
        float totalTime = dx / vx0;
        vy0 = (dy - (g * totalTime * totalTime / 2)) / totalTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xPos = Time.deltaTime * vx0;
        float t = xPos / vx0;
    }
}
