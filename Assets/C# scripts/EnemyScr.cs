using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();
    int wayIndex = 0;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetWaypoints();
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
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, currentWayPos) <0.3f)
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
                Destroy(gameObject);
        }
    }
}
