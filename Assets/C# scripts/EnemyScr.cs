using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPionts = new List<GameObject>();
    int wayIndex = 0;
    int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        wayPionts = GameObject.Find("Main Camera").GetComponent<GameCtrlScr>().wayPionts;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
