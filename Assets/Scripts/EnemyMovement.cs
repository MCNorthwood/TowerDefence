﻿using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wpIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.wp[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void getNextWaypoint()
    {
        if (wpIndex >= Waypoints.wp.Length - 1)
        {
            EndPath();
            return;
        }

        wpIndex++;
        target = Waypoints.wp[wpIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
