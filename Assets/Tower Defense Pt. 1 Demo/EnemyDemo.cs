using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death

    public int health = 3;
    public float speed = 3;
    public int coins = 3;

    public List<Transform> waypointList;
    private int targetWaypointIndex;
    private Vector3 newPosition;
    private Vector3 initDir;
    private Vector3 targetPosition;

    public delegate void EnemyDied(EnemyDemo deadEnemy);
    public event EnemyDied OnEnemyDied;

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypointList[0].position;
        targetWaypointIndex = 1;
        targetPosition = waypointList[targetWaypointIndex].position;
        initDir = (targetPosition - transform.position).normalized;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        if (targetWaypointIndex < waypointList.Count)
        {
            TargetNextWaypoint();
        }
       

        // todo #4 Check if destination reaches or passed and change target


        // bool enemyDied = false;
        // if (enemyDied)
        // {
        //     OnEnemyDied?.Invoke(this);
        // }
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        targetPosition = waypointList[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;
        newPosition = transform.position;
        newPosition += movementDir * speed * Time.deltaTime;

        transform.position = newPosition;

        if (Vector3.Dot(initDir, movementDir) < 0)
        {
            transform.position = waypointList[targetWaypointIndex].position;
            targetWaypointIndex++;
            if (targetWaypointIndex < waypointList.Count)
            {
                targetPosition = waypointList[targetWaypointIndex].position;
                initDir = (targetPosition - transform.position).normalized;
            }
            
        }
    }
}
