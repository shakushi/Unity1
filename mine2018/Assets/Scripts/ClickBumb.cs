using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBumb : MonoBehaviour
{
    private bool action = false;
    private bool WaitPush = true;
    private SpriteRenderer MainSpriteRenderer;
    public Sprite S_number0;
    public Sprite S_number1;
    public Sprite S_number2;
    public Sprite S_number3;
    public Sprite S_number4;
    public Sprite S_number5;
    public Sprite S_number6;
    public Sprite S_number7;
    public Sprite S_number8;
    int imageNum = 9;
    private GameObject cubeobj_1;
    private GameObject cubeobj_2;
    private GameObject cubeobj_3;
    private GameObject cubeobj_4;
    private string upname,downname,rightname,leftname;
    //string objectName;

    // Use this for initialization
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        string name = gameObject.name;
        int s = int.Parse(name);
        s = s / 100;
        int t = int.Parse(name) - (s * 100);

        if (t == 0) {
            upname = "out";
        }else{
            upname = s.ToString("D2") + (t - 1).ToString("D2");
            cubeobj_1 = GameObject.Find(upname);
        }
        if (s == 0) {
            leftname = "out";
        }else{
            leftname = (s - 1).ToString("D2") + t.ToString("D2");
            cubeobj_2 = GameObject.Find(leftname);
        }
        if (t == Constans.MapLimitY) {
            downname = "out";
        }else{
            downname = s.ToString("D2") + (t + 1).ToString("D2");
            cubeobj_3 = GameObject.Find(downname);
        }
        if (s == Constans.MapLimitX) {
            rightname = "out";
        }
        else
        {
            rightname = (s + 1).ToString("D2") + t.ToString("D2");
            cubeobj_4 = GameObject.Find(rightname);
        }

        //print(gameObject.name + " u:" + cubeobj_1.name + ", d:" + cubeobj_3.name +", l:" + cubeobj_2.name + ", r:" + cubeobj_4.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && WaitPush)
        {
            //objectName = gameObject.name;
            Vector3 mPosition = Input.mousePosition;
            mPosition.z = 10.0f;
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(mPosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d && collition2d.gameObject == gameObject) { action = true;  } else { action = false; }
            WaitPush = false;

        }
        if(Input.GetMouseButtonUp(0)){
            Vector3 mPosition = Input.mousePosition; mPosition.z = 10.0f;
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(mPosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
                if (collition2d && action) //&& objectName == gameObject.name
                {
                    if (collition2d.gameObject == gameObject) {
                    Openmasu();
                }
                }
            WaitPush = true;
            }

    }

    public void Openmasu()
    {
        if (gameObject.tag == "openMasu")
        {
            return;
        }
        else
        {
            gameObject.tag = "openMasu";
            imageNum = myMain.NumCheck(gameObject.name);
            switch (imageNum)
            {
                case 0:
                    MainSpriteRenderer.sprite = S_number0;
                    if (upname != "out" && cubeobj_1 != null)
                    {
                        ClickBumb a = cubeobj_1.GetComponent<ClickBumb>();
                        a.Openmasu();
                    }
                    else {  }
                    if (downname != "out" && cubeobj_3 != null)
                    {
                        ClickBumb b = cubeobj_3.GetComponent<ClickBumb>();
                        b.Openmasu();
                    }
                    if (rightname != "out" && cubeobj_4 != null)
                    {
                        ClickBumb c = cubeobj_4.GetComponent<ClickBumb>();
                        c.Openmasu();
                    }
                    if (leftname != "out" && cubeobj_2 != null)
                    {
                        ClickBumb d = cubeobj_2.GetComponent<ClickBumb>();
                        d.Openmasu();
                    }
                    break;
                case 1:
                    MainSpriteRenderer.sprite = S_number1;
                    break;
                case 2:
                    MainSpriteRenderer.sprite = S_number2;
                    break;
                case 3:
                    MainSpriteRenderer.sprite = S_number3;
                    break;
                case 4:
                    MainSpriteRenderer.sprite = S_number4;
                    break;
                case 5:
                    MainSpriteRenderer.sprite = S_number5;
                    break;
                case 6:
                    MainSpriteRenderer.sprite = S_number6;
                    break;
                case 7:
                    MainSpriteRenderer.sprite = S_number7;
                    break;
                case 8:
                    MainSpriteRenderer.sprite = S_number8;
                    break;
                case 9:
                    myMain.Explosion();
                    break;
            }

        }
    }
}