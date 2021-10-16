using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFishingScript : MonoBehaviour
{
    public bool cfishing;
    public bool fishing;
    public bool bite;

    public float maxLength = 70f;
    public float length = 0f;
    public float tention = 0f;

    public float maxPull = 0.47f;
    public float pulllength = 0.2f;

    public int fishCount = 0;
}
