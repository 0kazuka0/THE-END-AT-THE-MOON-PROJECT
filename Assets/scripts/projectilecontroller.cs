using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilecontroller : MonoBehaviour
{
    public float bulletspeed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
        {
            rb.AddForce(new Vector2(-1, 0) * bulletspeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(1, 0) * bulletspeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void removeforce()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
