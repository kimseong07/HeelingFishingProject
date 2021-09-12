using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelHandle : MonoBehaviour
{
    public GameObject handle;
    
    void Start()
    {
        
    }

    void Update()
    {
        handle.transform.localRotation = new Quaternion(0,0,0,0);
    }
}
