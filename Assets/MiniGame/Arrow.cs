using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    float Angle = 0.0f;        //回転角
    float RotSpeed = 2.0f;     //回転速度

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        Angle += RotSpeed;
    }
}
