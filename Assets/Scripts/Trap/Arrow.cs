
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    private float cooldownTimer;
    private void Attack()
    {
        cooldownTimer = 0;
        fireBalls[FindFireball()].transform.position = firePoint.position;
        fireBalls[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}