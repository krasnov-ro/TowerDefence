using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScr : MonoBehaviour
{
    float range = 2; 
    public float CurrCooldown, Cooldown;
    public GameObject TowerProjectilePref;

    private void Update()
    {
        if (CanShoot())
            SearchTarget();
        if(CurrCooldown > 0)
        {
            CurrCooldown -= Time.deltaTime;
        }
    }

    bool CanShoot()
    {
        if(CurrCooldown <= 0)
        {
            return true;
        }
        return false;
    }

    void SearchTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if(currDistance < nearestEnemyDistance &&
               currDistance <= range)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = currDistance;
            }
        }

        if (nearestEnemy != null)
            Shoot(nearestEnemy);
    }
    
    void Shoot(Transform enemy)
    {
        CurrCooldown = Cooldown;
        
        GameObject proj = Instantiate(TowerProjectilePref);
        proj.transform.position = transform.position;
        proj.GetComponent<TowerProjectileScr>().SetTarget(enemy);
    }
}
