using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilecontroller2 : MonoBehaviour
{
    public float bulletspeed;

    Rigidbody2D rb;

    public Sprite flashsprite;
    public int frametoflash = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(doflash());
        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
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

    IEnumerator doflash()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var originalsprite = renderer.sprite;
        renderer.sprite = flashsprite;

        var flameflashed = 0;
        while(flameflashed<frametoflash)
        {
            flameflashed++;
            yield return null;
        }
        renderer.sprite = originalsprite;
    }
    public void removeforce()
    {
        rb.velocity = new Vector2(0, 0);
    }

}
