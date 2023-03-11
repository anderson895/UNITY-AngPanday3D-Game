using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//to get canvas


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject progressPanel;
    //for variables
    public float fullHealth;
    float currentHealth;
    public bool playerDied = false;


    //for component of a player
    PlayerController pController;


    //for other game objects
    public Canvas playerCanvas;
    public Slider playerHealthSlider;


    // awake is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        playerHealthSlider.minValue=0;
        playerHealthSlider.maxValue=fullHealth;
        playerHealthSlider.value=currentHealth;

        pController = GetComponent<PlayerController>();
        progressPanel.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    //start add damage function
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;


        if(currentHealth<=0)
        {
            playerDied = true;
            playerCanvas.enabled = false;
            pController.Death();
            pController.enabled = false;
            progressPanel.SetActive(true);
        }
    }
    //end add damage function

    //start add health function
    public void AddHealth(float damage)
    {
        currentHealth += damage;
        playerHealthSlider.value = currentHealth;


        if (currentHealth <= 0)
        {
            playerDied = true;
            playerCanvas.enabled = false;
            pController.Death();
            pController.enabled = false;
        }
    }
    //end add health function

}