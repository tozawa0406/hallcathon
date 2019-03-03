using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFruit : MonoBehaviour {

    // 子要素の配列
    GameObject[] children = new GameObject[10];

    // 自分のフルーツタイプ
    FruitType MyFruitType;

    // 子要素のスプライトレンダラーオブジェクト
    private SpriteRenderer SpriteObject;

    // フルーツのスプライトホルダ
    private Sprite[] SpriteHolder = new Sprite[(int)FruitType.FRUITTYPE_MAX];

    // ノーツ配置配列
    int[,] NoteSet = new int[3, 10]
     {
        // 0 = GREEN, 1 = YELLOW, 2 = RED
        // EASY
        {2, 1, 1, 0, 0, 0, 0, 1, 1, 2},
        // NORMAL
        {2, 2, 1, 1, 0, 0, 1, 1, 2, 2},
        // HARD
        {2, 2, 2, 1, 0, 1, 1, 2, 2, 2}
     };

	// Use this for initialization
	void Awake () {

        //子要素を取得
        GameObject child = transform.GetChild(0).gameObject;
		for (int i = 0; i < 10; i++)
        {
            children[i] = child.transform.GetChild(i).gameObject;
        }

        // 子要素のスプライトオブジェクト取得
        SpriteObject = transform.GetChild(1).GetComponent<SpriteRenderer>();
        SpriteObject.sortingOrder = 10;

        // フルーツのスプライトをロード
        SpriteHolder[(int)FruitType.Apple] = Resources.Load<Sprite>("Fruit/リンゴ");
        SpriteHolder[(int)FruitType.Banana] = Resources.Load<Sprite>("Fruit/バナナ");
        SpriteHolder[(int)FruitType.Mellon] = Resources.Load<Sprite>("Fruit/メロン");
        SpriteHolder[(int)FruitType.Grape] = Resources.Load<Sprite>("Fruit/ブドウ");
        SpriteHolder[(int)FruitType.Peach] = Resources.Load<Sprite>("Fruit/桃");
        SpriteHolder[(int)FruitType.Tangerine] = Resources.Load<Sprite>("Fruit/みかん");

        Setup(FruitType.Apple, true);
	}
	
	// Update is called once per frame
	void Update () {
        SpriteObject.sprite = SpriteHolder[(int)MyFruitType];
	}

    public void Setup(FruitType type, bool is_match)
    {
        int add_difficult = 0;
        if (!is_match)
        {
            add_difficult = 1;
        }

        // 自分のフルーツタイプセット
        MyFruitType = type;

       switch(type)
        {
            case FruitType.Apple:
                Setup_notes(0 + add_difficult);
                break;
            case FruitType.Banana:
                Setup_notes(0 + add_difficult);
                break;
            case FruitType.Grape:
                Setup_notes(0 + add_difficult);
                break;
            case FruitType.Mellon:
                Setup_notes(0 + add_difficult);
                break;
            case FruitType.Peach:
                Setup_notes(0 + add_difficult);
                break;
            case FruitType.Tangerine:
                Setup_notes(0 + add_difficult);
                break;
        }
    }

    private void Setup_notes(int difficulty)
    {
        for (int i = 0; i < 10; i++)
        {
            children[i].GetComponent<HitNotes>().SetNoteType((HitNotes.NoteType)NoteSet[difficulty, i]);
        }
    }

    public void SetNotes_AllRed()
    {// 全部赤ノーツにする
        for (int i = 0; i < 10; i++)
        {
            children[i].GetComponent<HitNotes>().SetNoteType(HitNotes.NoteType.RED);
        }
    }

    public FruitType GetFruitType()
    {
        return MyFruitType;
    }
}