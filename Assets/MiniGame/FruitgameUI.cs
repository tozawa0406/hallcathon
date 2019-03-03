using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitgameUI : MonoBehaviour {

    // 簡易リスト制御変数
    int list_count = 0;

    // フルーツタイプ配列
    FruitType[] FruitList = new FruitType[4];

    // IsPerfect配列
    bool[] IsPerfectList = new bool[4];

    // 子要素格納変数
    GameObject[] children = new GameObject[4];

	// Use this for initialization
	void Start () {
        // リスト制御変数初期化
        list_count = 0;

        // 子要素オブジェクト取得
        for (int i = 0; i < 4; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
        transform.root.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update() {
		if(list_count >= 4)
        {
            //ここにスコア計算のやつ返す
            // フルーツの配列名 FruitList
            // isPerfectの配列名 IsPerfectList

            // スコア計算
            CalcRequest.CalcScore(CreateFruitsArray(FruitList), IsPerfectList);
            // 終了処理
            transform.parent.gameObject.SetActive(false);
        }
	}

    public void SetUp(Fruits[] inMixer, bool[] isMatch)
    {
        for(int i = 0; i < 4; i++)
        {
            children[i].GetComponent<TargetFruit>().Setup(inMixer[i].Type, isMatch[i]);
        }

        // リスト制御変数初期化
        list_count = 0;
    }

    public void PushFruitInfo(FruitType type, bool isPerfect)
    {
        FruitList[list_count] = type;
        IsPerfectList[list_count] = isPerfect;

        list_count++;
    }

    Fruits[] CreateFruitsArray(FruitType[] types)
    {
        Fruits[] retArray = new Fruits[4];
        for(int i = 0; i < 4; i++)
        {
            switch(types[i])
            {
                case FruitType.Apple:
                    retArray[i] = new Apple();
                    break;
                case FruitType.Banana:
                    retArray[i] = new Banana();
                    break;
                case FruitType.Grape:
                    retArray[i] = new Grape();
                    break;
                case FruitType.Mellon:
                    retArray[i] = new Mellon();
                    break;
                case FruitType.Peach:
                    retArray[i] = new Peach();
                    break;
                case FruitType.Tangerine:
                    retArray[i] = new Tangerine();
                    break;
            }
        }

        return retArray;
    }

    // inmixer ismatch

    // return fruit が perfectかどうか
}
