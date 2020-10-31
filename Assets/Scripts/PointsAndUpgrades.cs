﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndUpgrades : MonoBehaviour
{

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

    private GameObject currentWeapon;

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
        totPoints = 0;
        currentNecessaryPoints = pointsForFirstUpgrade;
        points = 0;
        upgradeInfoUI.active = false;
        currentWeapon = Instantiate(weapons[weapon], weaponsPosition[0].position, Quaternion.identity);
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
            }

            if (Input.GetKeyDown("2") && weapon < 2)
            {
                points -= currentNecessaryPoints;
                currentNecessaryPoints += pointsForFollowingUpdates;

                weapon++;

                Destroy(currentWeapon);
                currentWeapon = Instantiate(weapons[weapon], weaponsPosition[0].position, Quaternion.identity);
            }

            if (Input.GetKeyDown("3") && shield < 2)
            {
                points -= currentNecessaryPoints;
                currentNecessaryPoints += pointsForFollowingUpdates;

                shield++;
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
        if (weapon >= 2) return false;
        if (shield >= 2) return false;
        if (ship >= 2) return false;
        return true;
    }
}
