using UnityEngine;

public class Saw : Trap
{
    public Transform[] patrolPoints;
    public float speed = 5f;

    private int currentPatrolIndex = 0;

    
    void Update()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("Patrol points are not set.");
            return;
        }

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        Vector2 direction = (targetPatrolPoint.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Length)
            {
                currentPatrolIndex = 0;
            }
        }
    }
}
