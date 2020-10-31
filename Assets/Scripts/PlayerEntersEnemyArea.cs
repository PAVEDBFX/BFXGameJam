using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntersEnemyArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<EnemyController>().PlayerInSight(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<EnemyController>().PlayerInSight(true);
        }
    }
}
