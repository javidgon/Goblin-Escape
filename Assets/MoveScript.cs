using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public float speed;
    Rigidbody2D rigidbody;
    Animator anim;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (x > 0.0f)
        {
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkRight", true);

        } else if (x < 0.0f)
        {
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);

        }
        float mX = x * speed * Time.deltaTime;

        rigidbody.MovePosition(new Vector2(rigidbody.position.x + mX, rigidbody.position.y));

        if (Input.GetKey(KeyCode.Space))
        {
            float mY = y * speed * Time.deltaTime;

            rigidbody.AddForce(new Vector2(rigidbody.position.x, rigidbody.position.y + mY));
        }
    }
}
