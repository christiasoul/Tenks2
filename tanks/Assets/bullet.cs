﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed;
    Rigidbody2D mybody;
    bool isTurn = true;
    public GameObject tank;
	public float BulletSpawnDelay;
	public float BulletTimeCount;

	// Use this for initialization
	void Start () {
        mybody = GetComponent<Rigidbody2D>();
        mybody.velocity = speed* transform.up;
		BulletTimeCount = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
	    if(isTurn == true)
        {
            transform.rotation = tank.transform.rotation;
            mybody.velocity = speed * transform.up;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        tankControl tank = other.gameObject.GetComponent<tankControl>();
		if (tank != null && Time.time>BulletTimeCount+BulletSpawnDelay) {
			tank.getHit ();
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}
    }
}
