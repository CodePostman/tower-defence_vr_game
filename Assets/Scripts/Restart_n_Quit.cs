using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_n_Quit : MonoBehaviour {

    // Back to Main Menu
     public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    // Restart Game Level
    public void LoadLevel_1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
