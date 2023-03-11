using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//to Get Canvas

public class bigboss : MonoBehaviour
{
    //for variable
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;
    //for local comoponent

    //for global component
    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;
    private EnemyController enemyControll;
    // Awake is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;
        enemyControll = GetComponent<EnemyController>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

    }
    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            enemyDied = true;
            enemyCanvas.enabled = false;
            MakeDied();
        }

    }
    public void MakeDied()
    {
        enemyControll.Death();
        Destroy(gameObject, 3f);
    }
}
