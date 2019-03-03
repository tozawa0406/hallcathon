using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRequest : MonoBehaviour
{

	GameObject[] requests;

	// Use this for initialization
	void Start()
	{
		string[] typeName = { "", "リンゴ", "バナナ", "メロン", "ブドウ", "桃", "みかん" };
		requests = new GameObject[4];
		requests = GameObject.FindGameObjectsWithTag("request");

		FruitType[] types = new FruitType[4];
		types = GetComponentInParent<Customer>().Request;

		for (int i = 0; i < 4; i++)
        {
            SpriteRenderer renderer = requests[i].GetComponent<SpriteRenderer>();
			Sprite sprite = Resources.Load<Sprite>("Fruit/" + typeName[(int)types[i]]);
			renderer.sprite = sprite;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
