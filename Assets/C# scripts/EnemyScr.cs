using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPionts = new List<GameObject>();
    int wayIndex = 0;
    public int speed = 1;
    public GameObject wayPointsParent;

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
        for (int i = 0; i < wayPointsParent.transform.childCount; i++)
        {
            wayPionts.Add(wayPointsParent.transform.GetChild(i).gameObject);
        }
    }

    void Move()
    {
        Vector3 dir = wayPionts[wayIndex].transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, wayPionts[wayIndex].transform.position) <0.3f)
        {
            if (wayIndex < wayPionts.Count - 1)
            {
                wayIndex++;
            }
            else
                Destroy(gameObject);
        }
    }
}
