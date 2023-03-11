using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //to get time

public class addHealth : MonoBehaviour
{

    //for variable
    public float playerDamageAmount;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;
    //for component

    //for global component
    public GameObject playerObj;

    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //check if player in range to damage layer
        if (playerInRange == true)
        {
            DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObj = other.gameObject;
                playerInRange = true;
            }
            Destroy(gameObject, 0.05f);
        }
    }

    void OnTriggerExit(Collider other)
    {

        playerInRange = false;

    }
    public void DamagePlayer()
    {
        if (nextDamage <= DateTime.Now)
        {
            if (playerObj.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObj.GetComponent<PlayerHealth>().AddHealth(playerDamageAmount);
                nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
            }


        }
    }
}
