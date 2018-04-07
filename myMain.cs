using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static class Constans
{
    public const int BumbNum = 1;
    public const int Map_MasuNumX = 4;
    public const int Map_MasuNumY = 4;
    public const int MapLimitX = Map_MasuNumX - 1;
    public const int MapLimitY = Map_MasuNumY - 1;
}

public class myMain : MonoBehaviour
{

    public Transform masu;
    // Use this for initialization
    void Start()
    {
        int i,j,numX,numY;
        int x = 0;
        int y = 0;
        numX = Constans.Map_MasuNumX - 1;
        numY = Constans.Map_MasuNumY - 1;

        for (i = numX * (-1); i <= numX; i += 2)
            {
                for (j = numY * (-1); j <= numY; j += 2)
                {
                    var obj = Instantiate(masu, new Vector2(i, j), Quaternion.identity);
                    obj.name = x.ToString("D2") + y.ToString("D2");
                    obj.tag = "closingMasu";
                    y++;
                }
                y = 0;
                x++;
            }
        
    }
    ///  0000 0100 0200 
    ///  0001 0101 0201
    ///  0002 0102 0202


    void Update()
    {
        if (NumCheck() == Constans.BumbNum){
            
            //ゲームクリアの処理
        }
    }


    public static int NumCheck(string gameobjectName)
    {

        int num = 0;
        int[,] map = new int[4, 4] { {1,2,0,3 }, {4,5,6,4 }, {0,7,8,4 }, {2,3,7,5} };
        int position = int.Parse(gameobjectName);
        int x = position / 100;
        int y = position - (x * 100);
        num = map[x, y];
        if (num < 0 || num > 9) { print("Error number! : NumCheck"); }
        return num;
    }
    public static int NumCheck() {
        //未開のマスの数を返す
        int countOpenMasu = 0;
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("closingMasu");
        countOpenMasu = tagObjects.Length;
        return countOpenMasu;
    }

    public static void Explosion() {
        print("explosion");
        //爆発の演出とゲームオーバー
    }
}
