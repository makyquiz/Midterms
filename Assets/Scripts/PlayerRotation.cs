using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationRange = 5f;
    public float rotationSpeed = 5f; 

    void Update()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, rotationRange, LayerMask.GetMask("Enemy"));

        if (enemiesInRange.Length > 0)
        {
            Transform nearestEnemy = FindNearestEnemy(enemiesInRange);
            RotateTowards(nearestEnemy.position);
        }
    }

    Transform FindNearestEnemy(Collider[] enemies)
    {
        Transform nearestEnemy = enemies[0].transform;
        float minDistance = Vector3.Distance(transform.position, nearestEnemy.position);

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
        return nearestEnemy;
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rotationRange);
    }
}
