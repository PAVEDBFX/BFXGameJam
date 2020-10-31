using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        { 
            gameObject.GetComponentInParent<EnemyController>().EnemyHit(other.GetComponent<BulletProperties>().Damage());
        }
    }
}
