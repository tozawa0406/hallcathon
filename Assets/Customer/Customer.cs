using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerState
{
	CUSTOMERSTATE_NULL,
	Normal,
	Joy,
	Angry,
	CUSTOMERSTATE_MAX
}

public class Customer : MonoBehaviour
{
	/// <summary>
	/// 客の要求
	/// </summary>
	public FruitType[] Request { get; private set; }
	/// <summary>
	/// 客の状態
	/// </summary>
	public CustomerState State { get; private set; }
	/// <summary>
	/// 客の制限時間
	/// </summary>
	float Timer { get; set; }
	/// <summary>
	/// 客のポイント
	/// </summary>
	float Point { get; set; }

	private GameObject Popup { get; set; }


	public PopCustomer CustomerQueue { get; set; }

	// Use this for initialization
	void Awake()
	{
		Timer = 20;
		State = CustomerState.Normal;
		SetRequest();
		// 時間制限のカウントダウンを開始する
		StartCoroutine("CountTime");
	}

	// Update is called once per frame
	void FixedUpdate()
	{

	}

	/// <summary>
	/// 要求をセットする
	/// </summary>
	void SetRequest()
	{
		Request = new FruitType[4];

		for (int i = 0; i < 4; i++)
		{
			Request[i] = (FruitType)(Mathf.Floor(Random.value * (float)(FruitType.FRUITTYPE_MAX - 1)) + 1f);
		}
	}

	/// <summary>
	/// 時間制限用コルーチン(あるなら)
	/// </summary>
	/// <returns></returns>
	public IEnumerator CountTime()
	{
		while (Timer-- >= 5)
		{
			yield return new WaitForSecondsRealtime(1f);
		}
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Customer/客(怒)");
		if (renderer && sprite)
			renderer.sprite = sprite;
		while (Timer-- >= 0)
		{
			yield return new WaitForSecondsRealtime(1f);
		}
	}

	/// <summary>
	/// 客にミックスジュースを渡す
	/// </summary>
	/// <param name="fruits">ジュースに入れた果物のリスト</param>
	/// <param name="rate">ミニゲームのスコア？</param>
	public float GiveJuice(List<Fruits> fruits, int rate)
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Customer/客(喜)");
		if (renderer && sprite)
			renderer.sprite = sprite;
		DestroyCustomer();
		return 0;
	}

	/// <summary>
	/// 客終了処理
	/// </summary>
	public void DestroyCustomer()
	{
		CustomerQueue.inQueue = false;
		Destroy(gameObject);
	}
}
