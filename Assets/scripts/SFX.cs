using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static AudioClip coin,pw,bossintro,bossatk,bossintro2,bossatk2,bosskaboom;
    static AudioSource soundsorce;
    void Start()
    {
        coin = Resources.Load<AudioClip>("coin");
        pw = Resources.Load<AudioClip>("pw");

        

        bossintro = Resources.Load<AudioClip>("bossintro");
        bossatk = Resources.Load<AudioClip>("bossatk");
        bossintro2 = Resources.Load<AudioClip>("bossintro2");
        bossatk2 = Resources.Load<AudioClip>("bossatk2");
        bosskaboom = Resources.Load<AudioClip>("bosskaboom");
        soundsorce = GetComponent<AudioSource>();

        //เเละ ระเบิดทั้ง 3 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playsound(string clip)
    {
        switch (clip)
        {
            case "coin":
                soundsorce.PlayOneShot(coin);
                break;
            case "pw":
                soundsorce.PlayOneShot(pw);
                break;
            case "bossintro":
                soundsorce.PlayOneShot(bossintro);
                break;
            case "bossatk":
                soundsorce.PlayOneShot(bossatk);
                break;
            case "bossintro2":
                soundsorce.PlayOneShot(bossintro2);
                break;
            case "bossatk2":
                soundsorce.PlayOneShot(bossatk2);
                break;
            case "bosskaboom":
                soundsorce.PlayOneShot(bosskaboom);
                break;
        }
    }
}
