using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour {

    Collider2D EnteringCollision;

    // 判定文字ポジション
    private Vector3 JudgePosition = new Vector3(0.0f, -3f, 0.0f);

    // 判定文字Prefab
    private GameObject Judge_Perfect;
    private GameObject Judge_Great;
    private GameObject Judge_Bad;

    // Use this for initialization
    void Start () {
        //Prefab読み込み
        Judge_Perfect = Resources.Load<GameObject>("Prefab/judge_perfect");
        Judge_Great= Resources.Load<GameObject>("Prefab/judge_great");
        Judge_Bad = Resources.Load<GameObject>("Prefab/judge_bad");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnteringCollision = collision;
    }


    public void OnClick()
    {
        //カーソルの先に何もなかった場合
        if (EnteringCollision == null)
            return;

        // 当たったヒットノーツ
        HitNotes otherHitNotes = EnteringCollision.GetComponent<HitNotes>();

        // 当たったノーツのノーツタイプ
        HitNotes.NoteType otherNoteType = otherHitNotes.GetNoteType();

        // 当たったノーツのグループ親
        TargetFruit otherParentGroup = otherHitNotes.transform.parent.parent.GetComponent<TargetFruit>();

        // FruitGameUI
        FruitgameUI parentUIGroup = otherHitNotes.transform.parent.parent.parent.GetComponent<FruitgameUI>();

        GameObject CreatedObject;

        switch(otherNoteType)
        {
            case HitNotes.NoteType.GREEN:
                // 緑ノーツだったときの処理
                CreatedObject = Instantiate(Judge_Perfect, JudgePosition, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                CreatedObject.GetComponent<Renderer>().sortingOrder = 20;
                otherParentGroup.SetNotes_AllRed();
                parentUIGroup.PushFruitInfo(otherParentGroup.GetFruitType(), true);
                break;
            case HitNotes.NoteType.YELLOW:
                // 黄色ノーツだったときの処理
                CreatedObject = Instantiate(Judge_Great, JudgePosition, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                CreatedObject.GetComponent<Renderer>().sortingOrder = 20;
                otherParentGroup.SetNotes_AllRed();
                parentUIGroup.PushFruitInfo(otherParentGroup.GetFruitType(), false);
                break;
            case HitNotes.NoteType.RED:
                // 赤ノーツだったときの処理
                CreatedObject = Instantiate(Judge_Bad, JudgePosition, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                CreatedObject.GetComponent<Renderer>().sortingOrder = 20;
                break;
        }



    }
}
