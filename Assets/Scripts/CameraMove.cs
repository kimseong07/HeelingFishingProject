using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Image fadePanel;
    public bool fade;
    float fadeCount = 0f;

    public GameObject vcam;
    private void Start()
    {
        fade = false;
    }

    private void Update()
    {
        if(fade == true)
        {
            fadeCount += Time.deltaTime * 4f;
            fadePanel.color = new Color(0, 0, 0, fadeCount);
            if (fadePanel.color.a >= 1.0f)
            {
                fade = false;
            }
        }
        else
        {
            fadeCount -= Time.deltaTime * 4f;
            fadePanel.color = new Color(0, 0, 0, fadeCount);
            if(fadePanel.color.a <= 0.1f)
            {
                fadeCount = 0.1f;
            }
        }
    }
}
