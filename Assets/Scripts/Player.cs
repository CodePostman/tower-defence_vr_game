using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float rayLength = 100.0f;

    public Transform playerHead;

    public Material newMat;

    public int coins = 15;
 
    public BuildManager buildManager;

    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        Ray ray = new Ray(playerHead.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawRay(playerHead.position, playerHead.forward * rayLength, Color.white, 1.0f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Coin" && Input.GetMouseButtonDown(0))
            {
                coins++;

                Destroy(hit.collider.gameObject);                
            }

            if (hit.collider.gameObject.GetComponent<Platform>() && Input.GetMouseButtonDown(0))
            {
                if (coins >= 5)
                {
                    buildManager.InstantiateTurret(hit.collider.gameObject.transform);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}