using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonerock : MonoBehaviour
{
    public float movespeed = 30f;

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, movespeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag==("Player"))
        {
            gamevalue.rockscore++;
            SFX.playsound("coin");
            Destroy(gameObject);
        }
    }
}
