using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScr : MonoBehaviour
{
    public GameObject TowerProjectilePref;
    Tower selfTower;
    public TowerType selfType;
    GameCtrlScr gcs;
    int test = 1;

    private void Start()
    {
        gcs = FindObjectOfType<GameCtrlScr>();

        selfTower = new Tower(gcs.AllTowers[(int)selfType]);
        GetComponent<SpriteRenderer>().sprite = selfTower.Spr;

        InvokeRepeating("SearchTarget", 0, .1f);
    }

    private void Update()
    {
        if (CanShoot())
            SearchTarget();
        if(selfTower.CurrCooldown > 0)
        {
            test++;
            selfTower.CurrCooldown -= Time.deltaTime;
            //Debug.Log(selfTower.CurrCooldown + ": " + selfTower.Name + ": " + Time.deltaTime + " ::: " + test);
        }
    }

    bool CanShoot()
    {
        if(selfTower.CurrCooldown <= 0)
        {
            return true;
        }
        return false;
    }

    void SearchTarget()
    {
        if (CanShoot())
        {
            Transform nearestEnemy = null;
            float nearestEnemyDistance = Mathf.Infinity;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currDistance = Vector2.Distance(new Vector2(transform.position.x + .5f, transform.position.y - .5f), enemy.transform.position);

                if (currDistance < nearestEnemyDistance &&
                   currDistance <= selfTower.range)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currDistance;
                }
            }

            if (nearestEnemy != null)
                Shoot(nearestEnemy);
        } 
    } 
    
    void Shoot(Transform enemy)
    {
        test = 1;
        selfTower.CurrCooldown = selfTower.Cooldown;
        
        GameObject proj = Instantiate(TowerProjectilePref);
        proj.GetComponent<TowerProjectileScr>().selfTower = selfTower;
        proj.transform.position = new Vector2(transform.position.x + .5f, transform.position.y - .5f);
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
