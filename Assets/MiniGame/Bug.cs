using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    Sprite          sprite_;
    SpriteRenderer  spriteRenderer_;

    Rigidbody2D     rigidbody_;
    Vector3         target_;

    const float     SPEED = 50;
    const float     FRICTION = 0.8f;

    float           frame_ = 0;
    
    void Start ()
    {
        sprite_         = Resources.Load<Sprite>("effect");
        spriteRenderer_ = transform.GetComponentInChildren<SpriteRenderer>();		
        if(sprite_ && spriteRenderer_)
        {
            spriteRenderer_.sprite = sprite_;
        }

        rigidbody_ = GetComponent<Rigidbody2D>();

        target_ = new Vector3(0, 0, 0);
	}
	
	void Update ()
    {
        Vector3 vector = target_ - transform.position;

        frame_ += 0.1f;
        vector += (Quaternion.Euler(0, 0, 90) * vector.normalized) * Mathf.Sin(frame_) * 50;

        rigidbody_.AddForce(vector.normalized * SPEED);
        rigidbody_.velocity *= FRICTION;
	}
}

