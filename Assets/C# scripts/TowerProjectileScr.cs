using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    Transform target;
    public TowerProjectile selfProjectile;
    public Tower selfTower;
    GameCtrlScr gcs;

    // Start is called before the first frame update
    void Start()
    {
        gcs = FindObjectOfType<GameCtrlScr>();
        selfProjectile = gcs.AllTowersProjectiles[selfTower.type];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                Hit();
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * selfProjectile.speed);
            }
        }
        else
            Destroy(gameObject);
    }


    public void Hit()
    {
        switch(selfTower.type)
        {
            case (int)TowerType.FIRST_TOWER:
                target.GetComponent<EnemyScr>().StartSlow(3, 1);
                target.GetComponent<EnemyScr>().TakeDamage(selfProjectile.damage);
                break;
            case (int)TowerType.SECOND_TOWER:
                target.GetComponent<EnemyScr>().AOEDamage(2, 30);
                target.GetComponent<EnemyScr>().TakeDamage(selfProjectile.damage);
                break;
        }
    }
    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }
}
