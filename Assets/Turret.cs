using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float bps = 1f; //bullet per second

    private Transform target;
    private float timeUntillFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();

        if (!CheckTargetIsInRange()){
            target = null;
        } else {
            timeUntillFire += Time.deltaTime;

            if(timeUntillFire >= 1f / bps){
                Shoot();
                timeUntillFire = 0f;
            }
        }
    }

    private void Shoot(){
        if (bulletPrefab == null || firingPoint == null) {
            Debug.LogError("Bullet prefab or firing point is not assigned.");
            return;
        }

        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        if (bulletScript != null) {
            bulletScript.SetTarget(target);
        } else {
            Debug.LogError("Bullet script is not found on the instantiated bullet object.");
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange(){
         return Vector2.Distance(target.position, transform.position) < targetingRange;
    }
    private void RotateTowardsTarget(){
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }

}
