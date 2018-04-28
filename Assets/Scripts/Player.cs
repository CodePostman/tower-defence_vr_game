using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float rayLength = 100;

    public Transform playerHead;

    public Material newMat;

    public Text coinsCountText;

    public int coins = 6;

    void Start()
    {
        
    }

    void Update()
    {
        Raycast();

        coinsCountText.text = "Coins: " + coins.ToString();
    }

    private void Raycast()
    {
        Ray ray = new Ray(playerHead.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawRay(playerHead.position, playerHead.forward * rayLength, Color.white, 1.0f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Coin") && Input.GetMouseButtonDown(0))
            {
                coins++;
                Destroy(hit.collider.gameObject);                
            }

            if (hit.collider.gameObject.CompareTag("Platform"))
            {
                hit.collider.gameObject.GetComponent<Renderer>().materials[0] = newMat;
                return;
            }
        }
    }
}