using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int health;
    public float timeBetweenShots = 1;
    public GameObject Player;
    public GameObject bullet;
    public Transform bulletSpawningPoint;
    public int bulletDamage;
    public float bulletSpeed;

    private bool playerInArea = false;
    private bool reloaded = true;

    // Called by the big trigger volume around the enemy
    public void PlayerInSight (bool visible)
    {
        playerInArea = visible;
    }

    // Called by the small trigger volume of the enemy
    public void EnemyHit (int damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInArea && reloaded)
        {
            GameObject myBullet = Instantiate(bullet, bulletSpawningPoint.position, Quaternion.identity);
            myBullet.GetComponent<BulletProperties>().SetBulletProperties(bulletSpeed, Player, bulletDamage);
            myBullet.GetComponent<BulletProperties>().Fire();
            reloaded = false;
            StartCoroutine(Reload());
        }

        if (health <= 0)
        {
            // Things to do when enemy dies
            Player.GetComponent<PointsAndUpgrades>().killedEnemy("easy");
        } 
    }

    private IEnumerator Reload ()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        reloaded = true;
    }
}
