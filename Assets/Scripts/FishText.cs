using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishText : MonoBehaviour
{
    public Text length;
    Fishing fishing;
    void Start()
    {
        fishing = FindObjectOfType<Fishing>();
    }

    // Update is called once per frame
    void Update()
    {
        length.text = fishing.length.ToString();
    }
}
