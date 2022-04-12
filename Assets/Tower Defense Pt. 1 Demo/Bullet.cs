using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    private GameObject enemy;
    private EnemyDemo enemyDemo;

    public float speed = 70f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
    }
    
    public void Seek(Transform thisTarget)
    {
        target = thisTarget;
    }

    void HitTarget()
    {
        Destroy(gameObject);
        if (enemyDemo != null)
        {
            enemyDemo.Damage(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemy = collision.gameObject;
        enemyDemo = enemy.GetComponent<EnemyDemo>();
        // Debug.Log("this happened");
    }
}