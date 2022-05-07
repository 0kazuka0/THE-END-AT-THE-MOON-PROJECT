using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydmg : MonoBehaviour
{
    public float damage;
    public float damagerate;
    public float pushbackforce;

    float nextdamage;
    // Start is called before the first frame update
    void Start()
    {
        nextdamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&nextdamage<Time.time)
        {
            playerhp theplayerhp = collision.gameObject.GetComponent<playerhp>();
            theplayerhp.takedmg(damage);
            nextdamage = Time.time + damagerate;

            pushback(collision.transform);
        }
    }
    void pushback(Transform pushobj)
    {
        Vector2 pushdirection = new Vector2(0, (pushobj.position.y - transform.position.y)).normalized;
        pushdirection *= pushbackforce;
        Rigidbody2D pushRB = pushobj.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushdirection, ForceMode2D.Impulse);
    }
}
