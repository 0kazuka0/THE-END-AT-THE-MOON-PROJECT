using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp2 : MonoBehaviour
{
    public float enemyfullhp;
    public GameObject poweritem;

    float currenthp;

    bool death;

    private Animator anim;

    [Header("components")]
    [SerializeField] private Behaviour[] components;

   
    // Start is called before the first frame update
    void Start()
    {
        currenthp = enemyfullhp;

       
        anim = GetComponent<Animator>();

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
             foreach(Behaviour component in components)
                {
                    component.enabled = false;
                }
                
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
    public void psdie1()//playsound
    {
        SFX2.playsound("melee2die");
    }
    public void psdie2()//playsound
    {
        SFX2.playsound("melee3die");
    }
    public void psdie3()//playsound
    {
        SFX2.playsound("rangedie");
    }

}
