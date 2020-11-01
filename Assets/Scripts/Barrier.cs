using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    public int health;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health -= (other.gameObject.GetComponent<PointsAndUpgrades>().getShield() + 1) * 2;
        }
    }
}
