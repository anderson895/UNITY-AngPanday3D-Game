using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange : MonoBehaviour
{

    //global variable
    public EnemyController enemyControll;
    // Awaken is called before the first frame update
    void Awaken()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            //if player in the detection range play enemy run animation
            enemyControll.Run();
            enemyControll.playerInDetectionRange = true;
        }
    }
}
