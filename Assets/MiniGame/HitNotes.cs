using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotes : MonoBehaviour {

    // ノーツタイプ
    public enum NoteType
    {
        GREEN = 0,
        YELLOW,
        RED,
        MAX
    }
    private NoteType MyNoteType;

    // スプライトレンダラー
    SpriteRenderer MySpriteRenderer;
    private Sprite[] SpriteHolder;

	// Use this for initialization
	void Start () {
        // スプライトレンダラー取得
        MySpriteRenderer = GetComponent<SpriteRenderer>();

        // スプライトホルダーをノーツタイプ数の分確保
        SpriteHolder = new Sprite[(int)NoteType.MAX];

        // スプライトホルダに読み込み
        SpriteHolder[(int)NoteType.GREEN] = Resources.Load<Sprite>("Textures/circle_green");  // GREEN
        SpriteHolder[(int)NoteType.YELLOW] = Resources.Load<Sprite>("Textures/circle_yellow");  // YELLOW
        SpriteHolder[(int)NoteType.RED] = Resources.Load<Sprite>("Textures/circle_red");       // RED
    }
	
	// Update is called once per frame
	void Update () {
        // スプライト更新
        MySpriteRenderer.sprite = SpriteHolder[(int)MyNoteType];
	}

    public void SetNoteType(NoteType type)
    {
        MyNoteType = type;
    }

    public NoteType GetNoteType()
    {
        return MyNoteType;
    }
}
