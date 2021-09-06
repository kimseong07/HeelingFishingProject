using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelHandle : MonoBehaviour
{
    public GameObject handle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handle.transform.localRotation = new Quaternion(0,0,0,0);
    }
}
