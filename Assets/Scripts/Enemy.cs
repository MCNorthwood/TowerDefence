using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    public int health = 100;

    public int money = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wpIndex = 0;

    void Start()
    {
        target = Waypoints.wp[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += money;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if(wpIndex >= Waypoints.wp.Length - 1)
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
        Destroy(gameObject);
    }
}
