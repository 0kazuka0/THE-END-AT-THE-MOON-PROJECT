using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerhp : MonoBehaviour
{
    public float healthamount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            SFX.playsound("pw");
            playerhp thehp = collision.gameObject.GetComponent<playerhp>();
            thehp.addhp(healthamount);
            Destroy(gameObject);
        }
    }
}
