using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Building Turrets")]

    public GameObject turretPrefab;

    public Player player;

    private int _turretsCount = 0;
    public int turretsCount
    {
        get { return _turretsCount; }
        set { turretsCount = value; }
    }

    public void InstantiateTurret(Transform platform)
    {
        GameObject turret = Instantiate(turretPrefab, platform.position + Vector3.up * 0.4f, platform.rotation);
        player.coins -= 5;
        _turretsCount++;
    }
}
