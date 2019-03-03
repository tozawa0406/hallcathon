using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffect : MonoBehaviour {

    // 生存タイマー(フレーム)
    private int LifeTime = 40;

    // 拡大速度
    private float ScaleValue = 0.08f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 拡大
        Vector3 MyScale = transform.localScale;
        MyScale += new Vector3(ScaleValue, ScaleValue, ScaleValue);
        transform.localScale = MyScale;

        // 生存タイマ処理
        LifeTime--;
        if(LifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
