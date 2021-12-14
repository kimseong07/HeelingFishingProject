using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Portal : MonoBehaviour
{
    public GameObject vcam;

    public float vcamX;
    public float vcamY;

    public Text curText;
    public Transform curPosText;

    public float moveCurTextYDown = 0;
    public float moveCurTextYUp = 0;

    public string CurPosName = "";
    private float time = 2f;

    void Start()
    {
        curText = GameObject.Find("CurPosText").GetComponent<Text>();
        MoveCurPosText();
    }
    void Update()
    {

    }

    public void MoveCurPosText()
    {
        curPosText.DOMoveY(moveCurTextYDown, time);
        StartCoroutine(MoveCurText());
    }

    IEnumerator MoveCurText()
    {
        yield return new WaitForSeconds(time);

        curPosText.DOMoveY(moveCurTextYUp, 1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            vcam.transform.position = new Vector3(vcamX, vcamY, -20);
            MoveCurPosText();
            curText.text = CurPosName;
        }
    }
}
