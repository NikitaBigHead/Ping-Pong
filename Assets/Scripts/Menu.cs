using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public void pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void continiue () {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void exit()
    {
        Application.Quit();
    }
}
