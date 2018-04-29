using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public float fireRate = 0.5f;
    public float shootForce = 0.0f;
    public Transform gunEnd;
    public AudioSource shootAudio;
    public LineRenderer projectileLineRenderer;


    public void Init()
    {
        projectileLineRenderer.positionCount = 2;
    }

    public void ShootEnemy(Vector3 shootPoint, Vector3 force, GameObject targetGo)
    {
        projectileLineRenderer.enabled = true;
        projectileLineRenderer.SetPosition(0, gunEnd.position);
        projectileLineRenderer.SetPosition(1, shootPoint);

        targetGo.GetComponent<Enemy>().TakeDamage();
        shootAudio.Play();

    }

    public void ClearShootTrace()
    {
        projectileLineRenderer.enabled = false;
    }

}