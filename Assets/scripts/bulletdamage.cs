using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdamage : MonoBehaviour
{
    public float weapondmg;

    projectilecontroller pc;

    public GameObject effecthit;
    // Start is called before the first frame update
    private void Awake()
    {
        pc = GetComponentInParent<projectilecontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("shootable"))
        {
            pc.removeforce();
            Instantiate(effecthit, transform.position, transform.rotation);
            Destroy(gameObject);
            if(collision.gameObject.tag=="Enemy")
            {
                Enemyhp hurthenemy = collision.gameObject.GetComponent<Enemyhp>();
                hurthenemy.takedmg(weapondmg);
                
            }
            if (collision.gameObject.tag == "Enemy2")
            {                
                Enemyhp2 hurthenemy2 = collision.gameObject.GetComponent<Enemyhp2>();
                hurthenemy2.takedmg(weapondmg);
            }
            if (collision.gameObject.tag == "Boss")
            {
                BossHealth bosshp = collision.gameObject.GetComponent<BossHealth>();
                bosshp.takedmg(weapondmg);
            }
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            pc.removeforce();
            Instantiate(effecthit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            pc.removeforce();
            Instantiate(effecthit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
