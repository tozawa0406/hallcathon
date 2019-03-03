using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCustomer : MonoBehaviour
{

	public bool inQueue { get; set; }

	private GameObject customer { get; set; }


	// Use this for initialization
	void Start()
	{
		customer = GameObject.Find("Customer");
	}

	// Update is called once per frame
	void Update()
	{

	}

	public IEnumerator Pop()
	{
		while (true)
		{
			yield return new WaitForFixedUpdate();
			if (!inQueue)
			{
				yield return new WaitForSecondsRealtime(0.5f);
				GameObject newCustomer = Instantiate(customer, transform);
				newCustomer.GetComponent<Customer>().CustomerQueue = this;
				inQueue = true;
			}
		}
	}
}
