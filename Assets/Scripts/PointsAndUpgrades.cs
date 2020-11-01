using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndUpgrades : MonoBehaviour
{

    public int health;

    public int points;

    public int totPoints;

    public int pointsForEasyEnemy;
    public int pointsForMediumEnemy;
    public int pointsForHardEnemy;

    public int pointsForFirstUpgrade;
    public int pointsForFollowingUpdates;

    public GameObject upgradeInfoUI;

    public GameObject[] weapons;
    public GameObject[] ships;
    public GameObject[] shields;
    public Transform[] weaponsPosition;
    public Transform[] shieldsPosition;

    private GameObject currentWeapon;
    private GameObject currentShield;

    private int currentNecessaryPoints;

    private int easyEnemies = 0;
    private int mediumEnemies = 0;
    private int hardEnemies = 0;

    private int weapon = 0;
    private int shield = 0;
    private int ship = 0;

    // Start is called before the first frame update
    void Start()
    {
        upgradeInfoUI = GameObject.Find("UpgradeInfo");
        totPoints = 0;
        currentNecessaryPoints = pointsForFirstUpgrade;
        points = 0;
        upgradeInfoUI.active = false;
        currentWeapon = Instantiate(weapons[weapon], weaponsPosition[0].position, Quaternion.identity);
        currentWeapon.transform.parent = transform;
        currentShield = Instantiate(shields[shield], weaponsPosition[0].position, Quaternion.identity);
        currentShield.transform.parent = transform;
        selectShip(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= currentNecessaryPoints && IsThereSomethingToUpgrade())
        {
            // TODO: update text
            upgradeInfoUI.active = true;

            if (Input.GetKeyDown("1") && ship < 2)
            {
                points -= currentNecessaryPoints;
                currentNecessaryPoints += pointsForFollowingUpdates;

                ship++;
                selectShip(ship);
                upgradeInfoUI.active = false;
            }

            if (Input.GetKeyDown("2") && weapon < 2)
            {
                points -= currentNecessaryPoints;
                currentNecessaryPoints += pointsForFollowingUpdates;

                weapon++;

                Destroy(currentWeapon);
                currentWeapon = Instantiate(weapons[weapon], weaponsPosition[ship].position, Quaternion.identity);
                currentWeapon.transform.rotation = transform.rotation;
                currentWeapon.transform.parent = transform;
                upgradeInfoUI.active = false;

            }

            if (Input.GetKeyDown("3") && shield < 2)
            {
                points -= currentNecessaryPoints;
                currentNecessaryPoints += pointsForFollowingUpdates;

                shield++;

                Destroy(currentShield);
                currentShield = Instantiate(shields[shield], shieldsPosition[ship].position, Quaternion.identity);
                currentShield.transform.rotation = transform.rotation;
                currentShield.transform.parent = transform;
                upgradeInfoUI.active = false;

            }
        }
    }

    public void killedEnemy(string type)
    {
        switch (type)
        {
            case "easy":
                easyEnemies++;
                points += pointsForEasyEnemy;
                totPoints += pointsForEasyEnemy;
                break;
            case "medium":
                mediumEnemies++;
                points += pointsForMediumEnemy;
                totPoints += pointsForMediumEnemy;
                break;
            case "hard":
                mediumEnemies++;
                points += pointsForHardEnemy;
                totPoints += pointsForHardEnemy;
                break;
        }
    }

    private bool IsThereSomethingToUpgrade ()
    {
        if (weapon <= 2) return true;
        if (shield <= 2) return true;
        if (ship <= 2) return true;
        return false;
    }

    private void selectShip (int s)
    {
        for (int i = 0; i < 3; i++)
        {
            ships[i].active = false;
            //if (s == 1) Destroy(ships[0]);
            //if (s == 2) Destroy(ships[1]);
        }
        ships[s].active = true;
        currentWeapon.transform.position = weaponsPosition[s].position;
        currentShield.transform.position = shieldsPosition[s].position;
    }

    public void getDamage (int d)
    {
        health -= d;
    }

    public int getShield ()
    {
        return shield;
    }

    public int getShip ()
    {
        return ship;
    }
}
