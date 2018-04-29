using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_info : MonoBehaviour {

    public int killedEnemies = 0;
    public int baseLives = 5;

    public Player player;
    public Enemy enemy;
    public SpawnManager spawnManager;
    public BuildManager buildManager;

    public Text wavesCountText;
    public Text killedEnemiesCountText;
    public Text coinsCountText;
    public Text livesCountText;
    public Text turretsCountText;

	void Update ()
    {
        wavesCountText.text = "Wave: " + (spawnManager.currentWave + 1).ToString(); 
        killedEnemiesCountText.text = "Killed: " + killedEnemies.ToString();
        coinsCountText.text = "Coins: " + player.coins.ToString();
        livesCountText.text = "Lives: " + baseLives.ToString();
        turretsCountText.text = "Turrets: " + buildManager.turretsCount.ToString() + "/5";
    }
}
