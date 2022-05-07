using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp : MonoBehaviour
{
    public float enemyfullhp;
    public GameObject poweritem;

    float currenthp;

    bool death;
    
    private Animator anim;

    public enemydmg enmdmg;

    public static AudioClip melee1die; //sound
    static AudioSource soundsorce;

    // Start is called before the first frame update
    void Start()
    {
        currenthp = enemyfullhp;
       

        anim = GetComponent<Animator>();

        melee1die = Resources.Load<AudioClip>("melee1die");
      

        soundsorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takedmg(float damage)
    {
        if (damage <= 0) return;
        currenthp -= damage;
        SFX2.playsound("melee1hit");
       

        if (currenthp <= 0)
        {
            //dead();// no use
            if (!death)
            {
                enmdmg.damage = 0;
                anim.SetTrigger("die");
                death = true;
            }
        }
    }
    public void dead()
    {
        Instantiate(poweritem, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
    public void ps()//play sound
    {
        soundsorce.PlayOneShot(melee1die);
    }
   
}
