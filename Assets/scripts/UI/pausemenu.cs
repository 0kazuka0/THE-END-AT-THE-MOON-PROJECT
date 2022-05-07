using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool isgamepaused = false;
    [SerializeField] GameObject pausemenuset;
    [SerializeField] GameObject nopausemenuset;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (isgamepaused)
            {
                nopausemenuset.SetActive(true);
                resumegame();
            }
            else
            {
                nopausemenuset.SetActive(false);
                pausegame();
            }
        }
    }
    public void resumegame()
    {
        nopausemenuset.SetActive(true);
        pausemenuset.SetActive(false);
        Time.timeScale = 1f;
        isgamepaused = false;
    }
    private void pausegame()
    {
        pausemenuset.SetActive(true);
        Time.timeScale = 0f;
        isgamepaused = true;
    }
    public void loadmenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void exitgame()
    {
        Application.Quit();
    }
}
