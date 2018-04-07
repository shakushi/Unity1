using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        //GUI.TextField(new Rect(10, 10, 300, 60), "{Unity 2Dでゲームを作る本 Sample 2-1}\n戦車をクリックすると加速\nはなすと発射！");
        GUI.TextField(new Rect(10, 10, 50, 50), myMain.NumCheck().ToString());
        if (GUI.Button(new Rect(10, 80, 100, 20), "リセット")) { Application.LoadLevel(Application.loadedLevelName); }
    }

}
