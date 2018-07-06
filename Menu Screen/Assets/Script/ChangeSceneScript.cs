using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour {

    [SerializeField]
    Image fade;

    float alpha;

    string SceneName;
    bool load = false;

    enum SceneNumber
    {
        EMPTY,
        Z_TO_PLAY,
        Z_TO_MAIN,
        SPACE_TO_MENU,
        X_TO_MAIN
    };
    SceneNumber number = SceneNumber.EMPTY;

    // Use this for initialization
    void Start ()
    {
        alpha = 1;
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 1);

        SceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update ()
    {
        //ロードが終了したら
        if (!load)
        {
            //フェードアウト
            if (alpha >= 0)
            {
                fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
                alpha -= 0.01f;
            }
            else
            {
                load = true;
            }
        }
        else
        {
            //シーン遷移するボタンを押したら
            SceneBotton();
            
            //ボタンを押したら
            if(number != SceneNumber.EMPTY)
            {
                //コールチンでフェード処理を行う
                StartCoroutine(fadeImage(number));
            }
        }

    }

    IEnumerator fadeImage(SceneNumber SNumber)
    {
        //フェードイン
        if (alpha <= 1)
        {
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
            alpha += 0.01f;
            yield return 1;
        }

        //フェードインが終わったら
        if (alpha > 1)
        {
            //シーン遷移関数
            ChangeScene(SNumber);
        }
    }

    void SceneBotton()
    {
        //Zキーでシーン遷移起動
        if (Input.GetKeyDown(KeyCode.Z) && SceneName == "Main")
        {
            number = SceneNumber.Z_TO_PLAY;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && SceneName == "Play")
        {
            number = SceneNumber.Z_TO_MAIN;
        }
        //Spaceキーでシーン遷移起動
        else if (Input.GetKeyDown(KeyCode.Space) && SceneName == "Main")
        {
            number = SceneNumber.SPACE_TO_MENU;
        }
        //Xキーでシーン遷移起動
        else if (Input.GetKeyDown(KeyCode.X) && SceneName == "Menu")
        {
            number = SceneNumber.X_TO_MAIN;
        }
    }

    void ChangeScene(SceneNumber SNumber)
    {
        switch(SNumber)
        {
            case SceneNumber.EMPTY:
                number = SNumber;
                break;

            case SceneNumber.Z_TO_PLAY:
                //シーン遷移
                SceneManager.LoadScene("Play");
                break;

            case SceneNumber.Z_TO_MAIN:
                //シーン遷移
                SceneManager.LoadScene("Main");
                break;

            case SceneNumber.SPACE_TO_MENU:
                //シーン遷移
                SceneManager.LoadScene("Menu");
                break;

            case SceneNumber.X_TO_MAIN:
                //シーン遷移
                SceneManager.LoadScene("Main");
                break;

            default:
                number = SNumber;
                break;
        }
    }
}
