using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private GameObject player;
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xmin, xmax);
        float y = Mathf.Clamp(player.transform.position.y, ymin, ymax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
