using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public float range = 30.0f;
    public float fireRate = 0.5f;
    public float rayLength = 30.0f;

    [Header("Unity Setup Fields")]

    public Transform partToRotate;

    public Weapon weapon;

    public float turnSpeed = 10.0f;

    public Transform firePoint;

    private float shootTimer = 0.0f;

    private WaitForSeconds lineRendereVisibillityTime;

    void Start () {

        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);

        weapon.Init();

        lineRendereVisibillityTime = new WaitForSeconds(weapon.fireRate * 0.4f);
    }
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

	void Update () {

        Raycast();

        shootTimer += Time.deltaTime;

        if (target == null)
            return;
        // Target Lok On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);
	}

    private void Raycast()
    {
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        //Debug.DrawRay(firePoint.position, firePoint.forward * rayLength, Color.white, 1.0f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Enemy") && shootTimer >= weapon.fireRate)
            {
                MakeShot(hit.collider.gameObject, hit);
            }
        }
    }

    private void MakeShot(GameObject targetGo, RaycastHit hit)
    {
        weapon.ShootEnemy(hit.point, -hit.normal, targetGo);
        shootTimer = 0.0f;
        StartCoroutine(HandleLineRenderer());
    }

    private IEnumerator HandleLineRenderer()
    {
        yield return lineRendereVisibillityTime;
        weapon.ClearShootTrace();
    }


    // Чтобы увидеть зону поражения пушки
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
