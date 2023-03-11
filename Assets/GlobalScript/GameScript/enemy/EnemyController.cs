using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//toget nav mesh agent


public class EnemyController : MonoBehaviour
{

    //for variables

    //for local component NavMeshAgent
    private NavMeshAgent enemyNavMeshAgent;
    private Animator enemyAnimator;


    //for global component and gameObject
    public Transform playerTransform;
    public bool playerInDetectionRange = false;
    public PlayerHealth pHealth;
    public GameObject detectionFight;

    //Awake is called
    void Awake()
    {
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInDetectionRange == true)
        {
            /*if (pHealth.playerDied==true)
            {
                enemyNavMeshAgent.transform.LookAt(playerTransform);
                idle();
                detectionFight.SetActive(false);

            }
            else
            {*/
        
                enemyNavMeshAgent.transform.LookAt(playerTransform);//to make enemy look at player
                enemyNavMeshAgent.SetDestination(playerTransform.position + new Vector3(0, 0, 0.099f));//move enemy to player

            }

        

    }

    //Start Run function
    public void Run()
    {
        enemyNavMeshAgent.speed = 1f;
        enemyAnimator.SetTrigger("Run");
    }
    //END Run function

    //Start Idle Animation

        public void idle()
        {
        enemyNavMeshAgent.speed = 0f;
        enemyAnimator.SetTrigger("Idle");
        }
    //end idle animation

    //start attack
    public void Attack()
    {
        enemyAnimator.SetTrigger("Attack");
    }
    //end attack

    //Start Death Function
    public void Death()
    {
        enemyNavMeshAgent.speed = 0f;
        enemyAnimator.SetTrigger("Death");
    }
    //End Death Function
}
