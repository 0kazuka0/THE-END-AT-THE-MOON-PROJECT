using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        //1=pistol 2=smg 3=laser 4=rpg
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gamevalue.weapon = number;
            SFX.playsound("pw");
            Destroy(gameObject);
        }
    }
}
