using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawTimer : MonoBehaviour {

    public Sprite[] image = new Sprite[10];
    Image myImageComponent;

    // Use this for initialization
    void Awake () {
        myImageComponent = GetComponent<Image>();
    }
	
    public void Draw(int n)
    {
        myImageComponent.sprite = image[n];
    }
}
