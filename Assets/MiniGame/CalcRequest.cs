using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcRequest : MonoBehaviour
{
    static Fruits[] request_ = new Fruits[4];
    public FruitgameUI ui_;

    void Start()
    {
//        ui_.gameObject.SetActive(false);
    }

    public void SetRequest(Fruits[] request, Fruits[] mixer)
    {
        Fruits[] inMixer = new Fruits[4];
        for (int i = 0; i < 4; ++i)
        {
            inMixer[i] = new Fruits();
            inMixer[i].Type = FruitType.Null;
        }
        request_ = request;

        // 判定前にreqest.Typeをコピー
        FruitType[] copyFruit = new FruitType[4];
        for(int i = 0; i < 4; i++)
        {
            copyFruit[i] = request_[i].Type;
        }


        // 条件に一致しているか
        bool[] isMatch = new bool[4];
        for(int i = 0; i < 4;++i)
        {
            isMatch[i] = false;
            for (int j = 0; j < 4; ++j)
            {
                if ((request_[i] == mixer[j]) && inMixer[i].Type == FruitType.Null)
                {
                    request_[i].Type = FruitType.Null;
                    inMixer[i] = mixer[j];
                    isMatch[i] = true;
                    break;
                }
            }
        }

        // 判定が終わったので戻す
        for (int i = 0; i < 4; i++)
        {
            request_[i].Type = copyFruit[i];
        }

        for (int i = 0; i < 4; ++i)
        {
            if (inMixer[i].Type == FruitType.Null)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (request_[j].Type != FruitType.Null)
                    {
                        inMixer[i] = request_[j];
                        request_[j].Type = FruitType.Null;
                    }
                }
            }
        }
        request_ = request;

        // ノートの設定処理
//        ui_.gameObject.SetActive(true);
        ui_.SetUp(inMixer, isMatch);
    }

    static public void CalcScore(Fruits[] mixer, bool[] perfect)
    {
        int score = 0;
        for(int i = 0; i < 4;++i)
        {
            if(request_[i].Type == mixer[i].Type)
            {
                int s = 2;
                if (!perfect[i]) { s = (int)(s * 0.5f); }
                score += s;
            }
        }

        //timerオブジェクトを取得
        Timer timer = GameObject.Find("timer").GetComponent<Timer>();
        timer.addtime(score);
    }
}
