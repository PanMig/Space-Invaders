using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject enemyLazer;
	public float lazerSpeed = 15.0f;

	private float propability;
	public float fireRate = 0.5f;

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindGameObjectWithTag ("scoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		propability = fireRate * Time.deltaTime;
		if (Random.value < propability) {
			FireProjectile ();
		}
	}

	void FireProjectile(){
		GameObject lazer =  Instantiate (enemyLazer, transform.position, Quaternion.identity);
		lazer.GetComponent<Rigidbody2D> ().velocity = Vector3.down * lazerSpeed;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "playerLazer") {
			Destroy (this.gameObject);
			scoreManager.IncreaseScore ();
		}
	}
}
