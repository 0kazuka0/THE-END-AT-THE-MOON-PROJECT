using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text getscore;
    // Start is called before the first frame update
    void Start()
    {
        getscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        getscore.text = "" + gamevalue.rockscore;
    }
}
