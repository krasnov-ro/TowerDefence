using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScr : MonoBehaviour
{
    Transform target;
    public int speed = 7;

    // Start is called before the first frame update
    void Start()
    {

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
                Destroy(gameObject);

            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
            Destroy(gameObject);
    }


    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }
}
