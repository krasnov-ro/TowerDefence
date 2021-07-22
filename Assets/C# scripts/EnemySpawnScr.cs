 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnScr : MonoBehaviour
{
    public LvlManagerScr LMS;
    public float timeToSpawn = 4;
    int spawnCount = 0;
    public GameObject enemyPref;

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0)
        {
            StartCoroutine(SpawnEnemy(spawnCount + 1));
            timeToSpawn = 4;
        }

        timeToSpawn -= Time.deltaTime;
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(gameObject.transform, false);
            if(LMS == null)
            {

            }
            else 
            {

            }
            Transform startCellPos = LMS.wayPoints[0].transform;
            
            Vector3 startPos = new Vector3(startCellPos.position.x - startCellPos.GetComponent<SpriteRenderer>().bounds.size.x,
                                           startCellPos.position.y - startCellPos.GetComponent<SpriteRenderer>().bounds.size.y / 2,
                                           -1);

            tmpEnemy.transform.position = startPos;

            yield return new WaitForSeconds(0.2f);
        }
    }
}
