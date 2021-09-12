using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeScritpts : MonoBehaviour
{
    Fishing fishing;
    private void Awake()
    {
        fishing = FindObjectOfType<Fishing>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fishing.length <= 0)
        {

        }
    }
}
