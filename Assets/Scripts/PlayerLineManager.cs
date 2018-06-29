using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineManager : MonoBehaviour {

    public float speed = 10;
    private Rigidbody2D lineRigidbody;

	// Use this for initialization
	void Start () {
        lineRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        lineRigidbody.velocity = Vector2.right * speed; 
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("OnTriggerEnter2D: On method.");

        Debug.Log("Object collided: " + collision.gameObject.name);
        Debug.Log("Sound of the object: " + collision.GetComponent<ItemData>().item.Sound);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        //FindObjectOfType<AudioManager>().Play(collision.gameObject.GetComponent<Item>().Sound);
    }
}
