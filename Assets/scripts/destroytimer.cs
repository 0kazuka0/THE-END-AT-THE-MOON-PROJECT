using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroytimer : MonoBehaviour
{
    public float timer = 1f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void turnoff()
    {
        Destroy(gameObject);
    }
    public void changecs()
    {
        SceneManager.LoadScene(7);
    }
    public void ps()
    {
        SFX.playsound("bosskaboom");
    }
}
