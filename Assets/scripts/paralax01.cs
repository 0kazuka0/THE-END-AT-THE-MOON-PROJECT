using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax01 : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxeffectmultiplier;
    [SerializeField] private bool infinitehorizontal;
    [SerializeField] private bool infinitevertical;

    private Transform cameratranform;
    private Vector3 lastcameraposition;
    private float textureunitsizeX;
    private float textureunitsizeY;
    // Start is called before the first frame update
    void Start()
    {
        cameratranform = Camera.main.transform;
        lastcameraposition = cameratranform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureunitsizeX = texture.width / sprite.pixelsPerUnit;
        textureunitsizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltamovement = cameratranform.position - lastcameraposition;
        transform.position += new Vector3(deltamovement.x * parallaxeffectmultiplier.x, deltamovement.y * parallaxeffectmultiplier.y);
        lastcameraposition = cameratranform.position;
        
        if(infinitehorizontal)
        {
            if(Mathf.Abs(cameratranform.position.x-transform.position.x)>=textureunitsizeX)
            {
                float oofsetpositionX = (cameratranform.position.x - transform.position.x) % textureunitsizeX;
                transform.position = new Vector3(cameratranform.position.x + oofsetpositionX, transform.position.y);
            }
        }
        if(infinitevertical)
        {
            if(Mathf.Abs(cameratranform.position.y-transform.position.y)>=textureunitsizeY)
            {
                float offsetpositionY = (cameratranform.position.y - transform.position.y) % textureunitsizeY;
                transform.position = new Vector3(transform.position.x, cameratranform.position.y + offsetpositionY);
            }
        }
    }
}
