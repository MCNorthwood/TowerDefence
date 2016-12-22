using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wpIndex = 0;

    void Start()
    {
        target = Waypoints.wp[0];
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
            Destroy(gameObject);
            return;
        }

        wpIndex++;
        target = Waypoints.wp[wpIndex];
    }
}
