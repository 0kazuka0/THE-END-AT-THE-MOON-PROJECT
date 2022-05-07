using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class for_cutscene : MonoBehaviour
{
    [Header("time")]
    [SerializeField]private float waittime = 5f;
    [Header("scene")]
    [SerializeField] private int sceneindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait_time());
    }

   IEnumerator wait_time()
    {
        yield return new WaitForSeconds(waittime);
        SceneManager.LoadScene(sceneindex);
    }
}
