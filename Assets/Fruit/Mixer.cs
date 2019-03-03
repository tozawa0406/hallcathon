using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
	private GameObject nextButton;
	GameObject game_;
	public CalcRequest calc_;


	public List<Fruits> FruitsAdded { get; private set; }   // ミキサーに入っているフルーツのリスト
	public List<GameObject> tempFruits { get; set; }

	private void Awake()
	{
		FruitsAdded = new List<Fruits>();
		tempFruits = new List<GameObject>();

		game_ = GameObject.Find("MiniGame");
		nextButton = GameObject.Find("NextButton");
		nextButton.SetActive(false);
	}

	// フルーツを足す
	public void AddFruit(Fruits fruit)
	{
		FruitsAdded.Add(fruit);
		if (FruitsAdded.Count >= 4)
		{
			nextButton.SetActive(true);
		}
	}

	// 特定の種類のフルーツを削除する
	public void DeleteFruit(FruitType type)
	{
		foreach (Fruits f in FruitsAdded)
		{
			if (f.Type == type)
			{
				FruitsAdded.Remove(f);
				break;
			}
		}
	}

	// 入っているフルーツをリセットする
	public void ResetFruit()
	{
		FruitsAdded.Clear();
		foreach (GameObject g in tempFruits)
		{
			Destroy(g);
		}
		tempFruits.Clear();

	}

	// 総コストを取得する
	public int GetCost()
	{
		int rtn = 0;
		foreach (Fruits f in FruitsAdded)
		{
			rtn += f.Cost;
		}
		return rtn;
	}

	// 種類が特定数入っているかを返す
	public bool Includes(FruitType type, int num = 1)
	{
		foreach (Fruits f in FruitsAdded)
		{
			if (f.Type == type)
			{
				num--;
			}
			if (num <= 0) break;
		}
		if (num <= 0) return true;
		else return false;
	}

	public void OnClick()
	{
		Fruits[] fruits = new Fruits[4];

		for (int i = 0; i < 4; ++i)
		{
			fruits[i] = FruitsAdded[i];
		}

		// !!!第一引数を変更
		calc_.SetRequest(fruits, fruits);

		ResetFruit();
		nextButton.SetActive(false);
		game_.SetActive(true);
	}
}
