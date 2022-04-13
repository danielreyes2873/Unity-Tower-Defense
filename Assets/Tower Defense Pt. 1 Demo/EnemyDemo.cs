using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death

    public int startHealth = 3;
    private float health;
    public float speed = 3;
    public int coins = 3;
    public Player player;
    public List<Transform> waypointList;
    public Image healthbar;
    private int targetWaypointIndex;
    private Vector3 newPosition;
    private Vector3 initDir;
    private Vector3 targetPosition;

    public GameObject tower;
    private Tower _tower;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    // public GameObject body;

    // public delegate void EnemyDied(EnemyDemo deadEnemy);
    // public event EnemyDied OnEnemyDied;

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
        health = startHealth;
        StartCoroutine(MouseClickDamage());
        InvokeRepeating("FindTower", 0f, fireRate);
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        if (targetWaypointIndex < waypointList.Count)
        {
            TargetNextWaypoint();
        }

        // if (tower != null)
        // {
        //     if (fireCountdown <= 0)
        //     {
        //         DamageTower();
        //         fireCountdown = 1f / fireRate;
        //     }
        //     
        // }
        //
        // fireCountdown -= Time.deltaTime;

        // todo #4 Check if destination reaches or passed and change target
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

    public void Damage(int damage)
    {
        // Debug.Log("this works");
        health -= damage;
        healthbar.fillAmount = health / startHealth;
        Debug.Log($"Enemy Health: {health}");
        if (health <= 0)
        {
            player.AddCoins(coins);
            StartCoroutine(Die());
        }
    }

    IEnumerator MouseClickDamage()
    {
        while (true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitInfo.collider.gameObject.name.Equals("Enemy"))
                    {
                        Damage(1);
                    }
                }
            }
            yield return null;
        }
    }

    IEnumerator Die()
    {
        var p = gameObject.GetComponent<ParticleSystem>();
        var m = gameObject.GetComponent<MeshRenderer>();
        var c = transform.GetChild(1).gameObject;
        p.Play();
        m.enabled = false;
        c.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void DamageTower()
    {
        
    }

    void FindTower()
    {
        if (tower != null)
        {
            float distanceToTower = Vector3.Distance(transform.position, tower.transform.position);
            if (distanceToTower <= range)
            {
                _tower = tower.GetComponent<Tower>();
                if (_tower.health >= 0)
                {
                    _tower.Damage(1);
                }
            }
        } else if (tower == null)
        {
            CancelInvoke("FindTower");
        }
        
        
        
    }
    
}