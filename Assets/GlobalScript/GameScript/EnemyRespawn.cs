using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());    
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount<5)
        {
            xPos = Random.Range(1,30);
            zPos = Random.Range(1,15);
            Instantiate(theEnemy, new Vector3(xPos,1, zPos),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;

        }
    }
  
}
