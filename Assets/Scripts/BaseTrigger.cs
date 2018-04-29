using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour {

    private UI_info uiInfo;
    private Enemy enemy;

    void Start () {
        uiInfo = GameObject.FindGameObjectWithTag("UI").GetComponent<UI_info>();
        enemy = GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other == enemy)
        {
            Destroy(other);
            uiInfo.baseLives--;
        }
    }
}
