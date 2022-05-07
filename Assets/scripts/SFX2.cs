using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX2 : MonoBehaviour
{
    public static AudioClip melee1hit, melee2die, melee3die, rangedie,melee2atk, melee3atk;
    static AudioSource soundsorce;
    // Start is called before the first frame update
    void Start()
    {

        melee1hit= Resources.Load<AudioClip>("melee1hit");
        melee2die = Resources.Load<AudioClip>("melee2die");
        melee3die = Resources.Load<AudioClip>("melee3die");
        rangedie = Resources.Load<AudioClip>("rangedie");
        melee2atk = Resources.Load<AudioClip>("melee2atk");
        melee3atk = Resources.Load<AudioClip>("melee3atk");

        soundsorce = GetComponent<AudioSource>();
    }

    public static void playsound(string clip)
    {
        switch (clip)
        {
            case "melee1hit":
                soundsorce.PlayOneShot(melee1hit);
                break;
            case "melee2die":
                soundsorce.PlayOneShot(melee2die);
                break;
            case "melee3die":
                soundsorce.PlayOneShot(melee3die);
                break;
            case "rangedie":
                soundsorce.PlayOneShot(rangedie);
                break;
            case "melee2atk":
                soundsorce.PlayOneShot(melee2atk);
                break;
            case "melee3atk":
                soundsorce.PlayOneShot(melee3atk);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
