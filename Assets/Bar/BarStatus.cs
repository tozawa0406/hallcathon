using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BarStatus : MonoBehaviour
{
    float point = 0.01f;
    float gauge = 0;
    float H;
    float S;
    float V;

    private GameObject bar;
    Slider _slider;

    // Use this for initialization
    void Start()
    {        //gameObject取得 
        bar = GameObject.Find("Fill");
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        bar.gameObject.GetComponent<Image>().material.color = Color.green;
        Color.RGBToHSV(bar.gameObject.GetComponent<Image>().material.color, out H, out S, out V);
    }



    // Update is called once per frame
    void Update()
    {
        //左クリック(仮)
        if (Input.GetMouseButton(0))
        {
            gauge += point;
        }
        //右クリック(仮)
        else if (Input.GetMouseButton(1))
        {
            gauge -= point;
        }

        if (gauge <= -1f)
        {
            //炎上最大値(ゲームオーバー？)
            bar.gameObject.GetComponent<Image>().material.color = Color.red;
        }
        else if (gauge < 0)
        {
            // 炎上なう
            bar.gameObject.GetComponent<Image>().material.color = Color.yellow;
        }
        else if (gauge >= 1f)
        {
            H += 0.02f;

            if (H >= 1f)
            {
                H = 0f;
            }
            bar.gameObject.GetComponent<Image>().material.color = Color.HSVToRGB(H, S, V);
        }
        else
        {
            //正常
            bar.gameObject.GetComponent<Image>().material.color = Color.green;
        }
        //最大値 最小値
        gauge = Mathf.Clamp(gauge, -1f, 1f);
        //value値に代入
        _slider.value = Mathf.Abs(gauge);

    }
}