using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemyDamage : MonoBehaviour
{

    //for variables
    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightRange = false;


    //for local component

    //for global component and Game Ob
    public GameObject enemyObj;

    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (enemyInFightRange==true)
        {
            DamageEnemy();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            enemyObj=other.gameObject;
            enemyInFightRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Enemy")
        {
            enemyInFightRange = false;
        }
    }

    public void DamageEnemy()
    {
        if (nextDamage<=DateTime.Now)
        {
            if (enemyObj.GetComponent<EnemyHealth>().enemyDied==false)
            {
                enemyObj.GetComponent<EnemyHealth>().AddDamage(enemyDamageAmount);

            }
            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
