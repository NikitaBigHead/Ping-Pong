using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    
    public void onePlayer()
    {
        SceneManager.LoadScene("Game");
        DataScene.countPlayer = 1;
    }
    public void twoPlayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
        DataScene.countPlayer = 2;
    }
    public void exit()
    {
        Application.Quit();
    }
}
