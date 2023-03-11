using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DetectionFight : MonoBehaviour
{

    //for variable
    public bool playerInDetectionFight = false;
    public DateTime nextDamage;
    public float fightAfterTime;
    //for local component
    //for global component
    public EnemyController enemyControll;

    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;    
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //check if player in detection fight to attack

        if (playerInDetectionFight==true)
        {
            FightInDetectionFight();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            playerInDetectionFight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInDetectionFight = false;
        }
    }

    public void FightInDetectionFight()
    {
        if (nextDamage<=DateTime.Now)
        {
            enemyControll.Attack();
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(fightAfterTime));
        }
    }
}
