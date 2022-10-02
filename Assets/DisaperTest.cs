using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisaperTest : MonoBehaviour
{
    public bool lastOne;

    public GameObject winBlackOut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disappear()
    {
        if (lastOne)
        {
            winBlackOut.SetActive(true);
        }
        else Destroy(gameObject);
    }
}
