using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    float timeLeft = 60f;   //残り時間

    DrawTimer[] number = new DrawTimer[2];

    void Start()
    {
        number = GetComponentsInChildren<DrawTimer>();
        StartCoroutine("Counter");  
    }

    void Update()
    {
        if (timeLeft < 0)
        {
            SceneManagerController.Change();
        }
    }

    public IEnumerator Counter()
    {
        while (timeLeft >= 0)   
        {
            int n = (int)timeLeft % 10;             
            int m = (int)(timeLeft - n) / 10;
            number[0].Draw(n);
            number[1].Draw(m);
            timeLeft--;
            yield return new WaitForSecondsRealtime(1f);
        }
    }

   public void addtime(float add)      //残り時間にプラスする
    {
        timeLeft += add;
    }
}
