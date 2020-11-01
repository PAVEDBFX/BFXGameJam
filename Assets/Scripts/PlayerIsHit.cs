using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            gameObject.GetComponentInParent<PointsAndUpgrades>().getDamage(other.GetComponent<BulletProperties>().Damage());
        }
    }
}
