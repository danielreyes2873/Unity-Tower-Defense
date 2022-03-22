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
    private Vector3 mvmtDir;

    public delegate void EnemyDied(EnemyDemo deadEnemy);
    public event EnemyDied OnEnemyDied;

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypointList[0].transform.position;
        targetWaypointIndex = 1;
        initDir = (targetPosition - transform.position).normalized;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        
        
        

        // todo #4 Check if destination reaches or passed and change target

        if (targetWaypointIndex < waypointList.Count)
        {
            targetPosition = waypointList[targetWaypointIndex].position;
            if (Vector3.Dot(initDir,mvmtDir) < 0)
            {
                Debug.Log("we got inside this conditional");
                targetWaypointIndex++;
                initDir = (targetPosition - transform.position).normalized;
            }
            else 
            {
                
                mvmtDir = (targetPosition - transform.position).normalized;
                Debug.Log(mvmtDir);
                newPosition = transform.position;
                newPosition += mvmtDir * speed * Time.deltaTime;
                transform.position = newPosition;
                // TargetNextWaypoint();
            }
        }
        

        // bool enemyDied = false;
        // if (enemyDied)
        // {
        //     OnEnemyDied?.Invoke(this);
        // }
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        
    }
}
