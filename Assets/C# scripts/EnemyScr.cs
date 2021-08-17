using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();
    int wayIndex = 0;
    public Enemy enemySelf;

    // Start is called before the first frame update
    void Start()
    {
        GetWaypoints();

        GetComponent<SpriteRenderer>().sprite = enemySelf.Spr;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void GetWaypoints()
    {
        wayPoints = GameObject.Find("LvlGroup").GetComponent<LvlManagerScr>().wayPoints;
    }
    void Move()
    {
        Transform currentWayPoint = wayPoints[wayIndex].transform;
        Vector3 currentWayPos = new Vector3(currentWayPoint.position.x + currentWayPoint.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                             currentWayPoint.position.y - currentWayPoint.GetComponent<SpriteRenderer>().bounds.size.y / 2,
                                             -1);

        Vector3 dir = currentWayPos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemySelf.Speed);

        if(Vector3.Distance(transform.position, currentWayPos) <0.3f)
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
            {
                Destroy(gameObject);
                HealthManagerScr.Instance.Health -= 1;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        enemySelf.Health = enemySelf.Health - damage;
        if(enemySelf.Health <= 0)
        {
            Destroy(gameObject);
            MoneyManagerScr.Instance.GameMoney += 20;
        }
    }

    public void StartSlow(float duration, float slowValue)
    {
        StopCoroutine("GetSlow");
        enemySelf.Speed = enemySelf.StartSpeed;
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        enemySelf.Speed -= slowValue;
        yield return new WaitForSeconds(duration);
        enemySelf.Speed = enemySelf.StartSpeed;
    }

    public void AOEDamage(float range, float damage)
    {
        List<EnemyScr> enemies = new List<EnemyScr>();

        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector2.Distance(transform.position, go.transform.position) <= range)
                enemies.Add(go.GetComponent<EnemyScr>());
        }

        foreach (EnemyScr es in enemies)
        {
            es.TakeDamage(damage);
        }
    }
}
