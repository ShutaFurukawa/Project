using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

    //Ugiのtransform
    RectTransform UIPos;
    Vector2 pos;
    //初期座標
    Vector2 initPos;

	// Use this for initialization
	void Start ()
    {
        UIPos = GetComponent<RectTransform>();
        //初期座標設定
        initPos = UIPos.anchoredPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        pos = new Vector2(initPos.x, UIPos.anchoredPosition.y);

        //カーソルが最上段じゃなければ
        if (Input.GetKeyDown(KeyCode.UpArrow) && pos.y < initPos.y)
        {
            pos.y += 70;
            //カーソルを上に動かす
            GetComponent<RectTransform>().anchoredPosition = pos;
        }

        //カーソルが最下段じゃなければ
        if (Input.GetKeyDown(KeyCode.DownArrow) && pos.y > -initPos.y)
        {
            pos.y -= 70;
            //カーソルを下に動かす
            GetComponent<RectTransform>().anchoredPosition = pos;
        }
	}
}
