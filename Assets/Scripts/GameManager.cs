using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BaseTrigger baseTrigger;
    public SpawnManager spawnManager;
    public UI_info uiInfo;
    public GameObject ui_Interface;

    public Material skyGameOver;

    public Material skyGameWin;

    void Start ()
    {
		
	}
	

	void Update ()
    {
        if (baseTrigger.baseLives <= 0)
        {
            ui_Interface.SetActive(false);
            RenderSettings.skybox = skyGameOver;
            StartCoroutine(LoadGameOverScene());
        }

        if (baseTrigger.baseLives > 0 && spawnManager.currentWave > spawnManager.totalWaves)
        {
            ui_Interface.SetActive(false);
            RenderSettings.skybox = skyGameWin;            
            StartCoroutine(LoadGameWinScene());
        }
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    IEnumerator LoadGameWinScene()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
